using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugColissionWithNet : MonoBehaviour
{
    public string bugName; 
    private BugCollector bugCollector;

    private void Start()
    {
        bugCollector = FindObjectOfType<BugCollector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Net")) 
        {
            print("Bug caught with the net");

            if (bugCollector != null)
            {
                bugCollector.OnCatch(bugName);
            }

            Destroy(gameObject);
        }
    }
}

