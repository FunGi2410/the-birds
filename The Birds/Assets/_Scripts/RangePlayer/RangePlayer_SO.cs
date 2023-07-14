using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Range Player SO", order = 1)]
public class RangePlayer_SO : ScriptableObject
{
    public string playerName;
    public float timming;
    //public SoldierID soldierID;

    public float fireRate;
    public float damage;
    public float health;
    public float speedMoveBullet;

    [SerializeField]
    public GameObject bulletPrefab;
}

