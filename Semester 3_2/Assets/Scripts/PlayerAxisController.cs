using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxisController : MonoBehaviour
{
    [SerializeField] private PhysicsMover mover;
    [SerializeField] private Bullet bulletPrefab;
    
    private int equippedWeaponIndex = 0;
    [SerializeField] private List<Weapon> inventoryList = new List<Weapon>();
    
    
    private Vector2 inputDirection;

    private void Awake()
    {
        PlayerManager.SetPlayerMover(mover);
        PlayerManager.SetPlayerController(this);
    }

    public void AddWeapon(Weapon newWeapon)
    {
        if (inventoryList.Contains(newWeapon))
            return;
        inventoryList.Add(newWeapon);
        newWeapon.owner = mover;
        newWeapon.transform.SetParent(transform);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if (!inventoryList.Contains(weapon))
            return;
        
        var removedWeaponIndex = inventoryList.IndexOf(weapon);
        if (equippedWeaponIndex >= removedWeaponIndex)
        {
            equippedWeaponIndex--;
            if (equippedWeaponIndex < 0)
                equippedWeaponIndex = 0;
        }
        inventoryList.Remove(weapon);
    }

    private void Update()
    {
        if (mover == null)
        {
            GameLoopManager.SetGameState(GameLoopManager.GameState.GameOver);
            Time.timeScale = 0;
            enabled = false;
            return;
        }
        
        UpdateMovement();

        UpdateChangeWeapon();

        UpdateShootWeapon();
        
        UpdateMoverDirection();
    }

    private void UpdateMovement()
    {
        inputDirection.x = Input.GetAxis("Horizontal");
        inputDirection.y = Input.GetAxis("Vertical");
        inputDirection.Normalize();
    }

    private void UpdateChangeWeapon()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            float scrollDirection = Mathf.Sign(Input.mouseScrollDelta.y);
            equippedWeaponIndex += Mathf.RoundToInt(scrollDirection);
            if (equippedWeaponIndex < 0)
                equippedWeaponIndex = inventoryList.Count - 1;
            if (equippedWeaponIndex >= inventoryList.Count)
                equippedWeaponIndex = 0;
        }
    }

    private void UpdateShootWeapon()
    {
        if (equippedWeaponIndex >= inventoryList.Count)
            return;
        
        Weapon equippedWeapon = inventoryList[equippedWeaponIndex];
        if (equippedWeapon != null && Input.GetMouseButtonDown(0))
        {
            equippedWeapon.StartShooting();
        }
        else if (equippedWeapon != null && Input.GetMouseButtonUp(0))
        {
            equippedWeapon.StopShooting();
        }
    }

    private void UpdateMoverDirection()
    {
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
