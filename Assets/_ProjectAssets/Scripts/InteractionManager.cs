using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private static InteractionManager instance;
    public static InteractionManager Instance => instance;
    private Collider collider;
    private void OnTriggerEnter(Collider other)
    {
        collider = other;
    }
    public void InteractionPerformed()
    {
        Debug.Log(collider);
        switch (collider.tag)
        {
            case "Door":
                Debug.Log("Usa");
                break;
        }
    }
}
