using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class PlayerMovement : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Transform playerTransform;
    private bool hasMovementStarted;
    public Vector2 input;
    public bool inputE;
    public float speed;
    public CharacterController playerController;

    [SerializeField] private float gravity = -30f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpHeight = 3.5f;
    private Vector3 verticalVelocity = Vector3.zero;
    private bool isGrounded;
    private bool jump;



    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerTransform = GetComponent<Transform>();
        playerController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundMask);
        if (isGrounded)
        {
            verticalVelocity.y = 0f;
        }
        Vector3 velocity = (playerTransform.right * input.x + playerTransform.forward * input.y);
        if (hasMovementStarted)
        {
            playerController.Move(velocity * speed * Time.deltaTime);
        }
        if (jump)
        {
            if (isGrounded)
            {
                verticalVelocity.y = Mathf.Sqrt(-2f * jumpHeight * gravity);
            }
            jump = false;
        }
        verticalVelocity.y += gravity * Time.deltaTime;
        playerController.Move(verticalVelocity * Time.deltaTime);
    }
    public void JumpPerformed()
    {
        jump = true;
    }
    public void MovementStarted()
    {
        hasMovementStarted = true;
    }

    public void MovementCanceled()
    {
        hasMovementStarted = false;
    }

    public void MovementPerformed(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }



    public void InteractionStarted()
    {
        inputE = true;
    }

    public void InteractionCanceled()
    {
        inputE = false;
    }
}