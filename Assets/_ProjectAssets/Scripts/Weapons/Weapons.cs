using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class Weapons : MonoBehaviour
{
    public bool specialEffect;
    public float damage;
    public float fireRate;
    public int ammo;
    public float range;
    public float speed;

    public RaycastHit raycastHit;
    public LayerMask enemyLayer;
    public Camera fpsCamera;
    public float hit;

    public ParticleSystem muzzleflash;

    private static Weapons instance;
    public static Weapons Instance => instance;

    private void Awake()
    {
        SingletonlInitialization();
    }
    public void Shoot()
    {
        muzzleflash.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit))
        {
            Debug.Log(hit.transform);
            
            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage, false);
            }
        }
        
    }

    private void SingletonlInitialization()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

}