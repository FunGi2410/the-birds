using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyWaves
{
    [SerializeField] private List<Enemy> enemies;

    public List<Enemy> Enemies { get => enemies; set => enemies = value; }
}
