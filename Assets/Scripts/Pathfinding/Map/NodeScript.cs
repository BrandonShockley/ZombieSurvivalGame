using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour {
	
    public class NodeConnection
    {
        public bool valid;
        public NodeScript parent;
        public NodeScript node;
        public float cost;

        //Debug lines
        public void DrawLine()
        {
            if (parent != null && node != null)
            {
                GameObject go = GameObject.Instantiate(Resources.Load("Prefabs/DebugLine")) as GameObject;
                LineRenderer lr = go.GetComponent<LineRenderer>();
                lr.SetPosition(0, parent.transform.position);
                lr.SetPosition(1, node.transform.position);
                lr.startWidth = .02f;
                lr.endWidth = .05f;
                if (valid)
                {
                    lr.startColor = Color.green;
                    lr.endColor = Color.green;
                }
                else
                {
                    lr.startColor = Color.red;
                    lr.endColor = Color.red;
                }
            }
        }
    }

    public enum Directions{
        RIGHT,
        TOP_RIGHT,
        TOP,
        TOP_LEFT,
        LEFT,
        DOWN_LEFT,
        DOWN,
        DOWN_RIGHT,
        MAX
    }

    public NodeConnection[] connections = new NodeConnection[(int)Directions.MAX];

	void Awake ()
	{
        for (int i = 0; i < connections.Length; i++)
        {
            connections[i] = new NodeConnection();
            connections[i].parent = this;
        }
	}

    public void ValidateConnections(NavGridScript grid)
    {
        int numValidConnections = 0;
        for (int i = 0, raycastAngle = 0; i < (int)Directions.MAX; i++, raycastAngle += 45)
        {
            //Raycast to find walls
            Vector2 direction = new Vector2(Mathf.Cos(raycastAngle * Mathf.Deg2Rad), Mathf.Sin(raycastAngle * Mathf.Deg2Rad));
            RaycastHit2D result;
            if (raycastAngle % 90 == 0)
            {
                result = Physics2D.Raycast(transform.position, direction, grid.nodeSpacing);
                connections[i].cost = grid.nodeSpacing;
            }
            else
            {
                float distance = Mathf.Sqrt(2 * grid.nodeSpacing * grid.nodeSpacing);
                result = Physics2D.Raycast(transform.position, direction, distance);
                connections[i].cost = distance;
            }
            
            //Make connections
            connections[i].valid = result.collider == null;
            if (!connections[i].valid)
                connections[i].valid = result.collider.tag != "Wall";
            if (connections[i].valid)
                numValidConnections++;
            
        }
        if (numValidConnections < 3)
            for (int i = 0; i < (int)Directions.MAX; i++)
                connections[i].valid = false;
        for (int i = 0; i < (int)Directions.MAX; i++)
            if (connections[i].valid)
                connections[i].DrawLine();
    }
}
