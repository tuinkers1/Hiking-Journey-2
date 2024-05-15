using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugColissionWithNet : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
        {
            print("Bug caught with the net");
            Destroy(gameObject);
        }
    
}
