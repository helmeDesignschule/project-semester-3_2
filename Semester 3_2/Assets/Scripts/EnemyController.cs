using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Mover mover;
    [SerializeField] private EnemyAnimator animator;
    [SerializeField] private float preferredDistanceToPlayer = 4;
    [SerializeField] private float targetingTime = 1;

    [SerializeField] private Bullet bulletPrefab;

    private bool isTargetingPlayer = false;

    private void Awake()
    {
        GameLoopManager.onGameStateChange += OnGameStateChanged;
    }

    private void OnGameStateChanged(GameLoopManager.GameState newState)
    {
        if (newState == GameLoopManager.GameState.GameOver)
            enabled = false;
    }

    void Update()
    {
        if (isTargetingPlayer)
            return;
        
        float distanceToPlayer = Vector2.Distance(mover.GetPosition(), PlayerManager.GetPlayerMover().GetPosition());

        if (distanceToPlayer <= preferredDistanceToPlayer)
        {
            mover.CancelMovement();
            StartCoroutine(TargetAndShootPlayerCoroutine());
        }
        else
        {
            mover.SetMovementTarget(PlayerManager.GetPlayerMover().GetPosition());
        }
    }

    private IEnumerator TargetAndShootPlayerCoroutine()
    {
        isTargetingPlayer = true;
        
        
        Debug.Log("Start Targeting");
        
        animator.PlayTargetingAnimation(targetingTime);
        yield return new WaitForSeconds(targetingTime);
        
        Debug.Log("Shoot player");
        Bullet newBullet = Instantiate(bulletPrefab, mover.GetPosition(), Quaternion.identity);
        
        newBullet.Shoot(mover, PlayerManager.GetPlayerMover().GetPosition());
        
        isTargetingPlayer = false;
    }

    private void OnDestroy()
    {
        GameLoopManager.onGameStateChange -= OnGameStateChanged;
        UIController.instance.IncreaseScore(1);
    }
}
