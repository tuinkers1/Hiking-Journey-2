using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefaster : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController playerController = other.GetComponent<FPSController>();
            if (playerController != null)
            {
                playerController.walkSpeed = 7;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FPSController playerController = other.GetComponent<FPSController>();
            if (playerController != null)
            {
                playerController.walkSpeed = 7;
            }
        }
    }
}
