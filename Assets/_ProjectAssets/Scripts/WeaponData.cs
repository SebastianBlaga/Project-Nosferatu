using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Weapons")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float range;
    public int ammo;
    public int capacity;
    public bool specialEffect;
}
