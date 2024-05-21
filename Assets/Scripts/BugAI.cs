using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BugAI : MonoBehaviour
{
    private NavMeshAgent bugAI;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int wayPointIndex;
    [SerializeField] private Vector3 Target;

    private void Start()
    {
        bugAI = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    private void Update()
    {
        //Debug.Log(bugAI.remainingDistance);
        //Debug.Log(Vector3.Distance(transform.position, Target));
        if (bugAI.remainingDistance < 1)
        {
            IterateWayPointIndex();
            UpdateDestination();
            //Debug.Log(bugAI.remainingDistance);
        
        }
        
    }

    private void UpdateDestination()
    {

        Target = waypoints[wayPointIndex].position;
        bugAI.SetDestination(Target);
    }

    private void IterateWayPointIndex()
    {
        wayPointIndex++;
        if (wayPointIndex == waypoints.Length)
        {
            wayPointIndex = 0;
        }
    }
}
