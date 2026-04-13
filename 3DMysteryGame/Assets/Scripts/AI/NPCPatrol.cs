using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class NPCPatrol : MonoBehaviour
{
    public List<Transform> pathNodes = new List<Transform>();
    public float pathReachingRadius = 2f;

    private bool IsPathValid()
    {
       return this && pathNodes.Count > 0;
    }

    public Vector3 GetPositionOfPathNodes (int NodeIndex)
    {
        if (NodeIndex < 0 || NodeIndex >= pathNodes.Count || pathNodes[NodeIndex] == null)
        {
            return Vector3.zero;
        }
        return pathNodes[NodeIndex].position;
    }

    public Vector3 GetDestinationOnPath(Transform agent, int PathDestinationNodeIndex) {
        if (IsPathValid()) {
            return GetPositionOfPathNodes(PathDestinationNodeIndex);
        }else{
            return agent.position;
        }
    }

    public int UpdatePathDestination(Transform agent, int PathDestinationNodeIndex, bool inverseOrder = false) {
        if (IsPathValid()) {
           if ((agent.position - GetDestinationOnPath(agent, PathDestinationNodeIndex)).magnitude <= pathReachingRadius) {
                PathDestinationNodeIndex = inverseOrder ? (PathDestinationNodeIndex - 1) : (PathDestinationNodeIndex + 1);   
           }
            if (PathDestinationNodeIndex < 0) {
                PathDestinationNodeIndex += pathNodes.Count;
            }
            if (PathDestinationNodeIndex >= pathNodes.Count) {
                PathDestinationNodeIndex -= pathNodes.Count;
            }
        }
        return PathDestinationNodeIndex;
    }
}
