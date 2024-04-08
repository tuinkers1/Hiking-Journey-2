using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallRespawn : MonoBehaviour
{


    void FixedUpdate()
    {
        if (transform.position.y < 25.06)
        {
            transform.position = new Vector3(517.6f, 28.76f, 359.9f);
        }
    }


}

