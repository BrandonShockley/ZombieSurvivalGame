using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PathfinderScript {
	//Just used for this pathfinding
    private struct Node : IComparable<Node>
    {
        public NodeScript ns;
        public float totalCost;

        public int CompareTo(Node other)
        {
            if (this.totalCost > other.totalCost)
                return 1;
            else if (this.totalCost < other.totalCost)
                return -1;
            else return 0;
        }
    }

    //A sequence of nodes that leads as close as possible to target position from origin position
	static List<NodeScript> FindShortestPath(Vector2 originPos, Vector2 targetPos, NavGridScript grid)
    {
        NodeScript origin = null, target = null;
        float closestOriginDist = float.MaxValue, closestTargetDist = float.MaxValue;

        //Find closest node to origin and target
        foreach (List<NodeScript> list in grid.nodes)
            foreach (NodeScript node in list)
            {
                float oDist = (originPos - (Vector2)node.transform.position).magnitude;
                float tDist = (targetPos - (Vector2)node.transform.position).magnitude;
                if (oDist < closestOriginDist)
                {
                    closestOriginDist = oDist;
                    origin = node;
                }
                if (tDist < closestTargetDist)
                {
                    closestTargetDist = tDist;
                    target = node;
                }
            }
        if (origin == null || target == null)
            return null;

        

        return null;
    }

    /*static bool SearchNode(Node node, NodeScript target)
    {
        List<Node> path = new List<Node>();
        foreach (NodeScript.NodeConnection connection in origin.connections)
        {
            Node tNode;
            tNode.ns = connection.node;
            tNode.totalCost = connection.cost + FindDistanceToTarget(tNode.ns, target);
            path.Add(tNode);
        }
        path.Sort();
        
    }*/

    static float FindDistanceToTarget(NodeScript origin, NodeScript target)
    {
        return (origin.transform.position - target.transform.position).magnitude;
    }
}
