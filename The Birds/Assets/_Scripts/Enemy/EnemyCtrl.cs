using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCtrl : MonoBehaviour
{
    public UnityAction OneEnemyDead;
    /*public static EnemyCtrl Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }*/

    [SerializeField]
    protected MeleeEnemy_SO meleeEnemy_SO;

    public float maxHealth;
    [SerializeField] float currentHealth;
    public float CurrentHealth   
    {
        get { return currentHealth; }   
        set { currentHealth = value; }  
    }

    public float distanceToPlayer;

    protected virtual void Start()
    {
        this.maxHealth = meleeEnemy_SO.health;
        this.currentHealth = this.maxHealth;
    }

    public void TakeDamage(float dame)
    {
        this.currentHealth -= dame;

        //Debug.Log(this.currentHealth);

        if (this.currentHealth <= 0)
        {
            this.Dead();
        }
    }

    public void Dead()
    {
        Debug.Log("Enemy died");
        OneEnemyDead.Invoke();
        Destroy(gameObject);
    }
}
