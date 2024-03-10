using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyCtrl : LivingEntity
{
    public static UnityAction OnEnemyDead;

    [SerializeField]
    protected MeleeEnemy_SO meleeEnemy_SO;

    /*public float maxHealth;
    [SerializeField] float currentHealth;
    public float CurrentHealth   
    {
        get { return currentHealth; }   
        set { currentHealth = value; }  
    }*/

    //public float distanceToPlayer;
    protected override void Die()
    {
        base.Die();
        OnEnemyDead?.Invoke();
    }

    protected virtual void Start()
    {
        this.startingHealth = meleeEnemy_SO.health;
        this.health = this.startingHealth;
    }

    /*public void TakeDamage(float dame)
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
    }*/
}
