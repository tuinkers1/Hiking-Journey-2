using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    

public GameObject FLashLightOnPlayer;
public GameObject PickUpText;

    void Start()
    {
        FLashLightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            PickUpText.SetActive(true);

            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);

                FLashLightOnPlayer.SetActive(true);

                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       PickUpText.SetActive(false); 
    }


}
  
