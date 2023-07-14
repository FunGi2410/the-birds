using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyCtrl : EnemyCtrl
{
    public Transform attackPoint;

    float nextTimeToFire = 0f;

    public LayerMask playerLayer;

    private void Start()
    {
        GetComponent<EnemyMovement>().SetSpeed(this.meleeEnemy_SO.speedWalk);
    }

    void Update()
    {
        if (this.CheckFireRate())
        {
            this.Attack();
        }
    }

    bool CheckFireRate()
    {
        if (Time.time >= this.nextTimeToFire)
        {
            this.nextTimeToFire = Time.time + (1f / this.meleeEnemy_SO.fireRate);
            return true;
        }
        return false;
    }

    void Attack()
    {
        // animation
        // Detect enemies in range of attack
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(this.attackPoint.position, this.meleeEnemy_SO.attackRange, this.playerLayer);
        // Damage them
        foreach (Collider2D player in hitPlayers)
        {
            Debug.Log("We hit " + player.name);
            player.GetComponent<PlayerCtrl>().TakeDamage(this.meleeEnemy_SO.damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (this.attackPoint == null) return;
        Gizmos.DrawWireSphere(this.attackPoint.position, this.meleeEnemy_SO.attackRange);
    }
}
