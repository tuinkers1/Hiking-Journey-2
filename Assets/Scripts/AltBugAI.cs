using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AltBugAI : MonoBehaviour
{
    [SerializeField] private GameObject roomba;
    [SerializeField] private Transform[] destinations;

    private BugAI bugAi;

    private void Start()
    {
        bugAi = roomba.GetComponent<BugAI>();
    }

    private void Update()
    {   
        float height = Mathf.Lerp(transform.position.y, bugAi.waypoints[bugAi.wayPointIndex].position.y, Time.deltaTime);
        transform.position = new Vector3(roomba.transform.position.x, height, roomba.transform.position.z);
        transform.rotation = roomba.transform.rotation;
    }
}
