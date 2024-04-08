using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float gravity = 9.81f;
    private Vector3 direction = Vector3.zero;
    private Vector3 finalMove = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private float xInput = 0;
    private float zInput = 0;

    [Header("references")]
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    void Update()
    {
        CalculateInput();
        CalculateMovement();
        ApplyMovement();


    }
    void CalculateInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        //gravity
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;

        }
    }
    void CalculateMovement()
    {
        direction = transform.forward * zInput + transform.right * xInput;
        finalMove = direction.normalized * moveSpeed - velocity;
        
    }
    void ApplyMovement()
    {
        characterController.Move(finalMove * Time.deltaTime);
    }
}
