using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour
{
    public Transform transform;

    private void Awake()
    {
        transform = GetComponent<Transform>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SafeZone"))
        {
            transform.position = new Vector3(50.83f, 1, 108f);
        }
    }
}
