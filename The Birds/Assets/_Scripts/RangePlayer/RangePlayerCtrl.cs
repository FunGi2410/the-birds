using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePlayerCtrl : PlayerCtrl
{
    [SerializeField]
    Transform muzzle;

    float nextTimeToFire = 0f;
    public Transform objectContainer;

    [SerializeField] bool isAttack = false;
    Animator animator;

    protected override void Start()
    {
        base.Start();
        this.animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        this.Attack();

        // Raycast to Enemy to shoot
        //RaycastHit2D hit = Physics2D.Raycast(transform.GetChild(0).position, Vector2.right * UIManager.instance.HalfWidthOfCanvas);
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.GetChild(0).position, Vector2.right * UIManager.instance.HalfWidthOfCanvas);
        //Debug.DrawRay(transform.position, Vector2.right * UIManager.instance.HalfWidthOfCanvas, Color.red);

        bool isHaveEnemy = false;
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                isHaveEnemy = true;
                this.isAttack = true;
                Debug.DrawRay(transform.position, hit.transform.position - transform.position, Color.green);
            }
        }
        if (!isHaveEnemy) this.isAttack = false;
       /* print(hit.collider.name);
        if (hit.collider.CompareTag("Enemy"))
        {
            Debug.DrawRay(transform.position, hit.transform.position - transform.position, Color.green);
        }*/
    }

    public void CompletedAttackEvent(string mes)
    {
        if (mes.Equals("AttackAnimationEnded"))
        {
            this.animator.SetBool("IsAttack", false);
            this.InstanceBullet(this.muzzle);
        }
    }

    bool CheckFireRate()
    {
        if (Time.time >= this.nextTimeToFire)
        {
            this.nextTimeToFire = Time.time + (1f / this.rangePlayerSO.fireRate);
            return true;
        }
        return false;
    }

    protected void Attack()
    {
        if (this.CheckFireRate() && this.isAttack)
        {
            this.animator.SetBool("IsAttack", true);
        }

        /*if (PlayerCombat.Instance.isAttack)
        {
            if (this.CheckFireRate())`
            {
                this.InstanceBullet(this.muzzle);
            }
        }*/
    }

    public GameObject InstanceBullet(Transform origin)
    {
        //Debug.Log(this.rangePlayerSO.bulletPrefab.transform.localScale);
        GameObject projectile = Instantiate(this.rangePlayerSO.bulletPrefab, origin.transform.parent.parent);
        //GameObject projectile = Instantiate(this.rangePlayerSO.bulletPrefab, canvas.transform);
        projectile.GetComponent<RectTransform>().anchoredPosition = gameObject.GetComponent<RectTransform>().anchoredPosition;
        /*projectile.transform.localScale *= new Vector2(1 / transform.localScale.x, 1 / transform.localScale.y);
        projectile.transform.localScale *= new Vector2(1 / objectContainer.localScale.x, 1 / objectContainer.localScale.y);*/
        return projectile;
    }
}
