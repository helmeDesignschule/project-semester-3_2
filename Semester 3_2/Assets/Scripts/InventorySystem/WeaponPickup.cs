using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponPrefab;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Weapon newWeapon = Instantiate(weaponPrefab);
        PlayerManager.GetPlayerController().AddWeapon(newWeapon);
        Destroy(gameObject);
    }
}
