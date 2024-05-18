using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake : MonoBehaviour
{
    public WeaponData weapon;
    public float damage;
    public float range;

    public RaycastHit raycastHit;
    public LayerMask enemyLayer;
    public Camera fpsCamera;
    public float hit;


    private void Start()
    {
        damage = weapon.damage;
        range = weapon.range;
    }

    public void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform);

            Enemy target = hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage, false);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}