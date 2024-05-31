using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class BugAI : MonoBehaviour
{
    private NavMeshAgent bugAI;
    public Transform[] waypoints;
    public Transform[] fleePoints;
    private int fleepoint;
    public int wayPointIndex;
    [SerializeField] private Vector3 Target;
    [SerializeField] private Vector3 fleeTarget;

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
        //if (Input.GetKeyDown(KeyCode.P))
        {
           // FleeFromPlayer();
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

  /* private void FleeFromPlayer()
    {
        fleepoint = Random.Range(0, fleePoints.Length);
        fleeTarget = fleePoints[fleepoint].position;
        bugAI.SetDestination(fleeTarget);
        
    }*/
}
