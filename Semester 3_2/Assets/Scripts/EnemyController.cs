using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //TODO
    // x Keeping distance to player
    // x Targeting time
    // x Targeting the Player
    // x Shooting a projectile
    // - Player takes damage
    // - Line of sight?
    
    [SerializeField] private Mover mover;
    [SerializeField] private Mover playerMover;
    [SerializeField] private EnemyAnimator animator;
    [SerializeField] private float preferredDistanceToPlayer = 4;
    [SerializeField] private float targetingTime = 1;

    [SerializeField] private Bullet bulletPrefab;

    private bool isTargetingPlayer = false;
    
    void Update()
    {
        if (isTargetingPlayer)
            return;
        
        float distanceToPlayer = Vector2.Distance(mover.GetPosition(), playerMover.GetPosition());

        if (distanceToPlayer <= preferredDistanceToPlayer)
        {
            mover.CancelMovement();
            StartCoroutine(TargetAndShootPlayerCoroutine());
        }
        else
        {
            mover.SetMovementTarget(playerMover.GetPosition());
        }
    }

    private IEnumerator TargetAndShootPlayerCoroutine()
    {
        isTargetingPlayer = true;
        
        
        Debug.Log("Start Targeting");
        
        animator.PlayTargetingAnimation(targetingTime);
        yield return new WaitForSeconds(targetingTime);
        
        Debug.Log("Shoot player");
        Vector2 shootDirection = playerMover.GetPosition() - mover.GetPosition();
        shootDirection.Normalize();

        float bulletSize = bulletPrefab.GetComponent<CircleCollider2D>().radius;
        Vector2 bulletSpawnPosition = mover.GetPosition() + shootDirection * (mover.GetRadius() + bulletSize + .1f);
        
        Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPosition, Quaternion.identity);
        
        newBullet.Shoot(shootDirection);
        
        isTargetingPlayer = false;
    }
}
