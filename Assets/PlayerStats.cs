using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public UnityEngine.UI.Image healthBar;
    public float healthAmount = 100;
    public Animator animator;



    public void Update()
    {
        if (healthAmount <= 0)
        {
            animator.Play("PlayerDying");
            
        }
    }

    public void PlayerTakeDamage(float Damage)
    {
        healthAmount -= Damage;
        healthBar.fillAmount = healthAmount / 100;
    }

}

