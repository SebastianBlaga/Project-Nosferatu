using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public string enemyType;
    public float damage;
    public float health;
    public float speed;
    public float attackspeed;

}
