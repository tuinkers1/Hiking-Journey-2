using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetBehaviour : MonoBehaviour
{
    [SerializeField] private Collider netCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void EnableCollider()
    {
        netCollider.enabled = true;
    }

    public void DisableCollider()
    {
        netCollider.enabled = false;
    }
}
