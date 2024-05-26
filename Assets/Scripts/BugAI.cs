using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugAI : MonoBehaviour
{
    private NavMeshAgent bugAI;
    public Transform[] waypoints;
    public int wayPointIndex;
    [SerializeField] private Vector3 Target;

    private void Start()
    {
        bugAI = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    private void Update()
    {
        Debug.Log(bugAI.remainingDistance);
        //Debug.Log(Vector3.Distance(transform.position, Target));
        if (bugAI.remainingDistance < 1 && !bugAI.pathPending)
        {
            IterateWayPointIndex();
            UpdateDestination();        
        }
    }

    private void UpdateDestination()
    {
        Target = waypoints[wayPointIndex].position;
        bugAI.destination = Target;
    }

    private void IterateWayPointIndex()
    {
        wayPointIndex += 1;
        
        if (wayPointIndex == waypoints.Length)
        {
            wayPointIndex = 0;
        }
    }
}
