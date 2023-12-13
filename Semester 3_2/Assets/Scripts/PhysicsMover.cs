using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class PhysicsMover : MoverBase
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private Animator animator;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MoveInDirection(Vector2 direction)
    {
        rigidBody.AddForce(direction * movementSpeed, ForceMode2D.Force);
        if (direction.magnitude > 0)
        {
            animator.SetFloat("moveDirectionX", direction.x);
            animator.SetFloat("moveDirectionY", direction.y);
        }
    }

    private void FixedUpdate()
    {
        animator.SetFloat("moveSpeed", rigidBody.velocity.magnitude);
    }
}
