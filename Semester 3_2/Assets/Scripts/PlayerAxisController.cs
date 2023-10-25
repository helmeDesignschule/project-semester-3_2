using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisController : MonoBehaviour
{
    [SerializeField] private PhysicsMover mover;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Weapon equippedWeapon;
    
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

        if (equippedWeapon != null && Input.GetMouseButtonDown(0))
        {
            equippedWeapon.StartShooting();
        }
        else if (equippedWeapon != null && Input.GetMouseButtonUp(0))
        {
            equippedWeapon.StopShooting();
        }

        Vector2 worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 moverToMouse = worldMousePosition - mover.GetPosition();
        moverToMouse.Normalize();
        mover.SetLookDirection(moverToMouse);
    }

    private void FixedUpdate()
    {
        if (mover != null)
            mover.MoveInDirection(inputDirection);
    }
}
