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

    [SerializeField] GameObject canvas;

    /*private AnimationEventHandler eventHandler;
    public event Action OnExit;

    private void Awake()
    {
        this.eventHandler = GetComponent<AnimationEventHandler>();
    }*/

    protected override void Start()
    {
        base.Start();
        this.animator = GetComponent<Animator>();
        this.canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    private void Update()
    {
        this.Attack();
    }

    /*private void Exit()
    {
        this.OnExit?.Invoke();
    }

    private void OnEnable()
    {
        this.eventHandler.OnFinish += Exit;
    }

    private void OnDisable()
    {
        this.eventHandler.OnFinish -= Exit;
    }*/

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
