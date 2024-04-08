using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    /*
    private float mouseX = 0;
    private float mouseY = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    */


    
    [Header("References")]
    [SerializeField] private Transform cameraFollow;

    [Header("Settings")]
    public Cinemachine.AxisState xAxis, yAxis;


    private void Update()
    {
        xAxis.Update(Time.deltaTime);
        yAxis.Update(Time.deltaTime);
    }

    private void LateUpdate()
    {
        cameraFollow.eulerAngles = new Vector3(yAxis.Value, cameraFollow.eulerAngles.y, cameraFollow.eulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis.Value, transform.eulerAngles.z);
    }
    
}
