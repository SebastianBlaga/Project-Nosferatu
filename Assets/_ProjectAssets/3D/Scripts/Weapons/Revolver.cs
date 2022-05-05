
using UnityEngine;

public class Revolver : MonoBehaviour
{
    public float damage = 30f;
    public float range = 100f;
    public bool effect = false;

    public Camera fpsCam;
    public ParticleSystem muzzle;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzle.Play();
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage, effect);
            }
        }


    }
}
