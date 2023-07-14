using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangePlayerCtrl : PlayerCtrl
{
    [SerializeField]
    Transform muzzle;

    float nextTimeToFire = 0f;
    public Transform objectContainer;

    //Canvas canvas;

    /*private void Start()
    {
        this.canvas = FindObjectOfType<Canvas>();
    }*/

    private void Update()
    {
        this.Attack();
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
        if (this.CheckFireRate())
        {
            this.InstanceBullet(this.muzzle);
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
        Debug.Log(this.rangePlayerSO.bulletPrefab.transform.localScale);
        GameObject projectile = Instantiate(this.rangePlayerSO.bulletPrefab, origin.transform);
        projectile.transform.localScale *= new Vector2(1 / transform.localScale.x, 1 / transform.localScale.y);
        projectile.transform.localScale *= new Vector2(1 / objectContainer.localScale.x, 1 / objectContainer.localScale.y);
        return projectile;
    }
}
