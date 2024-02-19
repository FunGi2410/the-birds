using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : LivingEntity
{
    [SerializeField]
    protected RangePlayer_SO rangePlayerSO;

    //private float currentHealth;
    protected virtual void Start()
    {
        this.startingHealth = this.rangePlayerSO.health;
        this.health = this.startingHealth;
    }

   /* public void TakeDamage(float dame)
    {
        this.currentHealth -= dame;

        *//*if(this.currentHealth <= 0)
        {
            this.Dead();
        }*//*
    }*/
}
