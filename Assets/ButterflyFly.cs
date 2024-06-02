using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyFly : MonoBehaviour
{
    [SerializeField]
    private Transform midpoint;

    [SerializeField]
    private float maxDistance;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        Vector3 toMid = midpoint.position - transform.position;
        float distanceToMid = toMid.magnitude;

        Vector3 randomDirection = Random.onUnitSphere;

        Quaternion randomQ = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(randomDirection), rotateSpeed * Time.deltaTime);
        Quaternion toMidQ = Quaternion.LookRotation(toMid);

        transform.rotation = Quaternion.Lerp(randomQ, toMidQ, /* how much random, vs how much to mid, look at documentation of lerp*/)


        /*
        OLD
        if (distanceToMid < maxDistance)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(randomDirection), rotateSpeed *Time.deltaTime);
                return;
        }   

        transform.rotation = Quaternion.LookRotation(toMid);

        Quaternion.Lerp(randomDirection, toMidDirection, closenessToMax);


        before changing maxdistance, want to lerp and slightly already move towards that direction
        */
    }
}