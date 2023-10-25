using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisController : MonoBehaviour
{
    [SerializeField] private PhysicsMover mover;
    [SerializeField] private Bullet bulletPrefab;
    
    private Vector2 inputDirection;

    private void Awake()
    {
        PlayerManager.SetPlayerMover(mover);
    }

    private void Update()
    {
        if (mover == null)
            Time.timeScale = 0;
        
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
        inputDirection.Normalize();

        if (mover != null && Input.GetMouseButtonDown(0))
        {
            //shoot bullet
            Bullet newBullet = Instantiate(bulletPrefab, mover.GetPosition(), Quaternion.identity);

            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newBullet.Shoot(mover, targetPosition);
        }
    }

    private void FixedUpdate()
    {
        if (mover != null)
            mover.MoveInDirection(inputDirection);
    }
}
