using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D myRigidbody2D;
    Vector2 moveInput;
    float speed;

    private void Start()
    {
        this.myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        this.Move();
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void Move()
    {
        this.moveInput = Vector2.left;
        Vector2 moveVelocity = this.moveInput.normalized * this.speed;
        this.myRigidbody2D.MovePosition(myRigidbody2D.position + moveVelocity * Time.fixedDeltaTime);
    }

}
