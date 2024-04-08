using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampsiteBuilding : MonoBehaviour
{

    // the coordinates of the place
    [SerializeField] private Vector3 location;

    // the raycast for location
    private RaycastHit _hit;

    // object references
    [SerializeField] private GameObject ObjectToPlace, tempObject, campfire, tempCampfire;

    //some value storing
    private bool placeNow, placingCampfire, tempExists;


    // Update is called once per frame
    void Update()
    {
        if (placeNow == true)
        {
            SendRay();
            PlaceingHandler();
        }

        if (placingCampfire == true)
        {
            ObjectToPlace = campfire;

        }

        if (Input.GetKeyDown("e"))
        {
            PlaceCampfire();

        }

    }
        
        void SendRay()
        {

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out _hit))
            {

                location = new Vector3(_hit.point.x, _hit.point.y, _hit.point.z);

                if (_hit.transform.CompareTag("Terrain"))
                {

                    if (tempExists == false)
                    {
                        Instantiate(tempCampfire, location, Quaternion.identity);
                        tempObject = GameObject.Find("Cube (1)(Clone)");
                        tempExists = true;
                    }

                   

                    if (tempObject != null)
                    {
                        tempObject.transform.position = location;

                    }
                    

                    

                }


            }

        }

            void PlaceCampfire()
            {
                placeNow = true;
                placingCampfire = true;
            }

        void PlaceingHandler()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Destroy(tempObject);
                placeNow = false;
                placingCampfire = false;
               
                tempExists = false;
            }
            if (Input.GetMouseButton(0))
            {
                Destroy(tempObject);
                Instantiate(ObjectToPlace, location, Quaternion.identity);
                placeNow = false;
                placingCampfire = false;
                tempExists = false;

            }
        }




        
    
}
