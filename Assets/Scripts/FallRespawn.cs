using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{


    void FixedUpdate()
    {
        if (transform.position.y < 1.47f)
        {
            transform.position = new Vector3(-4.64f, 4.53f, 2.7f);
        }
    }


}

