using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public string bulletName;
    //public BulletID bulletID;

    [SerializeField]
    protected RangePlayer_SO rangePlayerSO;

    public Vector2 direction;
    Rigidbody2D myRigidbody2D;

    float timmer = 0;

    private void Start()
    {
        this.myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void FixedUpdate()
    {
        this.MoveToAttack();
        this.OnDestroy();
    }

    protected virtual void MoveToAttack()
    {
        this.myRigidbody2D.MovePosition(this.myRigidbody2D.position + this.direction * this.rangePlayerSO.speedMoveBullet * Time.fixedDeltaTime);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);
        /*if(collision.gameObject.tag == "Enemy")
        {
            EnemyCtrl enemyCtrl = collision.transform.GetComponent<EnemyCtrl>();
            if(enemyCtrl == null)
            {
                Debug.Log("EnemCtrl Script is missing!!!");
                return;
            }
            enemyCtrl.TakeDamage(this.rangePlayerSO.damage);
            //print(collision.name + " " + enemyCtrl.CurrentHealth);
        }*/
    }

    protected virtual void OnDestroy()
    {
        this.timmer += Time.fixedDeltaTime;
        if(this.timmer >= this.rangePlayerSO.timming)
        {
            Destroy(gameObject);
        }
    }

}
