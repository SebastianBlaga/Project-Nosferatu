using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponManager : MonoBehaviour
{
    private static WeaponManager instance;
    public static WeaponManager Instance => instance;

    private Vector2 input;
    public int selectedWeapon = 0;


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
    }

    private void Start()
    {
        ChooseWeapon();
    }
    public void SelectWeapon(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();


        int previousSelectedWeapon = selectedWeapon;
        if (input.y > 0)
        {
            if (selectedWeapon >= transform.childCount - 1)
            {
                selectedWeapon = 0;
            }
            else
            {
                selectedWeapon++;
            }
        }

        if (input.y < 0)
        {
            if (selectedWeapon <= 0)
            {
                selectedWeapon = transform.childCount - 1;
            }
            else
            {
                selectedWeapon--;
            }
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            ChooseWeapon();
        }
    }
    void ChooseWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }

    public void Attack()
    {
        switch (selectedWeapon)
        {
            case 0:
                Fists.instance.Attack();
                break;
            case 1:
                Sword.instance.Attack();
                break;
            case 2:
                Revolver.instance.Attack();
                break;
            case 4:
                //NYI
                break;
            case 5:
                //NYI
                break;
            case 6:
                //NYI
                break;
            case 7:
                //NYI
                break;
            case 8:
                //NYI
                break;
            default:
                break;
        }
    }
}
