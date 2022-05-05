using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    private static MouseLook instance;
    public static MouseLook Instance => instance;
    [SerializeField] float sensitivityX = 25f;
    [SerializeField] float sensitivityY = 0.5f;
    float mouseX;
    float mouseY;
    private bool rotationY;
    private bool rotationX;

    [SerializeField] Transform playerCamera;
    [SerializeField] float xClamp = 55f;
    float xRotation = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    private void Update()
    {
        if (rotationX != false)
        {
            transform.Rotate(Vector3.up, mouseX * Time.deltaTime);
        }

        if (rotationY != false)
        {

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
            Vector3 targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            playerCamera.eulerAngles = targetRotation;
        }
    }

    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * sensitivityX;
        mouseY = mouseInput.y * sensitivityY;
    }

    public void MouseStopY()
    {
        rotationY = false;
    }
    public void MouseStartY()
    {
        rotationY = true;
    }

    public void MouseStartX()
    {
        rotationX = true;
    }

    public void MouseStopX()
    {
        rotationX = false;
    }
}
