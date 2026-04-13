using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class NPCController : MonoBehaviour
{
  public NavMeshAgent m_NavMeshAgent { get; private set; }

    public NPCPatrol patrolPath;
    public int m_PathDestinationNodeIndex = 0;

    void Start() {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void SetNavDestination(Vector3 destination) {
        if (m_NavMeshAgent.enabled) {
            m_NavMeshAgent.SetDestination(destination);
        }
    }
}
