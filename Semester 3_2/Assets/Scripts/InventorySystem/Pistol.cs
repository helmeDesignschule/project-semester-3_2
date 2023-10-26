using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AmmoBasedWeapon
{
    [Header("Pistol")]
    [SerializeField] private Bullet bulletPrefab;
    
    public override void ShootBullet()
    {
        Bullet newBullet = Instantiate(bulletPrefab, owner.GetPosition(), Quaternion.identity);
        newBullet.Shoot(owner, owner.GetPosition() + owner.GetLookDirection());
    }
}
