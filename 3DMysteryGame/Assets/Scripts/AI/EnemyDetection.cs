using UnityEngine;
using UnityEngine.AI;
using System.Collections;   

public class EnemyDetection : MonoBehaviour
{
    [Header("Detection Settings")]
    public Transform player;
    public float viewRadius = 15f;
    [Range(0, 180)] public float viewAngle = 180f;

    [Header("Wander Settings")]
    public float wanderRadius = 10f;
    public float idleTime = 3f;

    private NavMeshAgent agent;
    private bool isChasing = false;
    private bool isLookingAround = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(WanderRoutine());
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            isChasing = true;
            StopAllCoroutines(); 
            isLookingAround = false;
            agent.SetDestination(player.position);
        }
        else if (isChasing)
        {
            isChasing = false;
            StartCoroutine(WanderRoutine());
        }
    }

    bool CanSeePlayer()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= viewRadius)
        {
           
            Vector3 dirToPlayer = (player.position - transform.position);
            dirToPlayer.y = 0;

            float angle = Vector3.Angle(transform.forward, dirToPlayer.normalized);
            if (angle <= viewAngle / 2f) return true;
        }
        return false;
    }

    IEnumerator WanderRoutine()
    {
        while (true)
        {
           
            Vector3 targetPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(targetPos);

           
            while (agent.pathPending || agent.remainingDistance > agent.stoppingDistance)
            {
                yield return null;
            }

           
            isLookingAround = true;
            float lookTimer = 0;
            while (lookTimer < idleTime)
            {
               
                float angle = Mathf.Sin(Time.time * 2f) * 45f;
                transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y + angle * Time.deltaTime, 0);
                lookTimer += Time.deltaTime;
                yield return null;
            }
            isLookingAround = false;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;
        randDirection += origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
        return navHit.position;
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
        Vector3 leftBoundary = Quaternion.AngleAxis(-viewAngle / 2, transform.up) * transform.forward;
        Vector3 rightBoundary = Quaternion.AngleAxis(viewAngle / 2, transform.up) * transform.forward;
        Gizmos.DrawRay(transform.position, leftBoundary * viewRadius);
        Gizmos.DrawRay(transform.position, rightBoundary * viewRadius);
    }
}
