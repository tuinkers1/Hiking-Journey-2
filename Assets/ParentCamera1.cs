using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentCamera1 : MonoBehaviour
{
    public Transform target; // Reference to the target object (parent1 capsule)
    public float smoothSpeed = 0.5f; // Speed of camera movement
    public float transitionDelay = 5f; // Delay before switching back to player camera

    private bool isTransitioning = false; // Flag to check if camera is transitioning
    private Camera playerCamera; // Reference to the player camera

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main; // Get the reference to the player camera
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTransitioning)
        {
            // Make the camera look at the face of the parent1 capsule
            transform.LookAt(target);

            // Show dialogue that says "hello world"
            //Debug.Log("Hello World");

            // Start the transition after 5 seconds
            StartCoroutine(TransitionToPlayerCamera());
        }
    }

    IEnumerator TransitionToPlayerCamera()
    {
        isTransitioning = true;

        yield return new WaitForSeconds(transitionDelay);

        // Smoothly transition back to the player camera
        while (transform.position != playerCamera.transform.position || transform.rotation != playerCamera.transform.rotation)
        {
            transform.position = Vector3.Lerp(transform.position, playerCamera.transform.position, smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerCamera.transform.rotation, smoothSpeed * Time.deltaTime);
            yield return null;
        }

        isTransitioning = false;
    }
}
