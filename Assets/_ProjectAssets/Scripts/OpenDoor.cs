using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour
{
    private bool action;
    private bool openedDoor = false;
    public Animator animator;
    public Animation animation;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            action = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            action = false;
        }
    }

    private void Update()
    {
        if (PlayerManager.Instance.GetPlayerMovement().inputE)
        {
            if (action)
            {
                animator.Play("DoorAnimation");
                openedDoor = true;
                action = false;
            }
        }

        if (openedDoor == true)
        {
            StartCoroutine(closeDoor());
        }
    }

    IEnumerator closeDoor()
    {
        yield return new WaitForSeconds(5);
        animator.Play("CloseDoor");
        openedDoor = false;
    }
}
