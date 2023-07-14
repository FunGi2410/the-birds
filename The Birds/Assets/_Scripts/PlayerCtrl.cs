using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField]
    protected RangePlayer_SO rangePlayerSO;

    private float currentHealth;
    void Start()
    {
        this.currentHealth = this.rangePlayerSO.health;
    }

    public void TakeDamage(float dame)
    {
        this.currentHealth -= dame;

        /*if(this.currentHealth <= 0)
        {
            this.Dead();
        }*/
    }
}
