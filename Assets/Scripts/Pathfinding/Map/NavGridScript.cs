using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavGridScript : MonoBehaviour {

    public bool showNodes;
    public float nodeSpacing;
    public Transform nodePrefab;

    Rect bounds;

    public List<List<NodeScript>> nodes;

	void Start ()
	{
        bounds.size = GetComponent<BoxCollider2D>().size / 2f;
        bounds.position = -bounds.size;

        nodes = new List<List<NodeScript>>();

        //Generate nodes in square pattern and add to grid array
        GenerateNodes();
        GenerateAndValidateConnections();
	}
	
    void GenerateNodes()
    {
        int arrayX = 0, arrayY = 0;
        for (float x = bounds.position.x; x < bounds.size.x; x += nodeSpacing)
        {
            nodes.Add(new List<NodeScript>());
            for (float y = bounds.position.y; y < bounds.size.y; y += nodeSpacing)
            {
                Vector2 nodePos = new Vector2(x, y);
                Transform node = Instantiate<Transform>(nodePrefab, nodePos, new Quaternion(), this.transform);
                nodes[arrayX].Add(node.GetComponent<NodeScript>());
                node.GetComponent<SpriteRenderer>().enabled = showNodes;
                arrayY++;
            }
            arrayY = 0;
            arrayX++;
        }
    }

    void GenerateAndValidateConnections()
    {
        //Ugh... I hate myself for this
        for (int x = 0; x < nodes.Count; x++)
            for (int y = 0; y < nodes[0].Count; y++)
            {
                //Making connections
                bool right = x + 1 >= nodes.Count;
                bool left = x - 1 < 0;
                bool up = y + 1 >= nodes[0].Count;
                bool down = y - 1 < 0;

                nodes[x][y].connections[0].node = right ? null : nodes[x + 1][y];
                nodes[x][y].connections[1].node = right || up ? null : nodes[x + 1][y + 1];
                nodes[x][y].connections[2].node = up ? null : nodes[x][y + 1];
                nodes[x][y].connections[3].node = up || left ? null : nodes[x - 1][y + 1];
                nodes[x][y].connections[4].node = left ? null : nodes[x - 1][y];
                nodes[x][y].connections[5].node = left || down ? null : nodes[x - 1][y - 1];
                nodes[x][y].connections[6].node = down ? null : nodes[x][y - 1];
                nodes[x][y].connections[7].node = right || down ? null : nodes[x + 1][y - 1];

                //Validating connections
                nodes[x][y].ValidateConnections(this);
            }
    }

	void Update ()
	{
		
	}
}
