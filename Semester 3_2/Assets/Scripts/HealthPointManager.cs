using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointManager : MonoBehaviour
{
    [SerializeField] private int maximumHealthPoints = 10;
    [SerializeField] private GameObject splashVFXPrefab;
    private int currentHealthPoints;

    private void Awake()
    {
        currentHealthPoints = maximumHealthPoints;
    }

    public void DealDamage(int amount, Vector2 damageDirection)
    {
        SpawnSplash(damageDirection);
        
        currentHealthPoints -= amount;
        if (currentHealthPoints <= 0)
            Destroy(gameObject);
    }

    private void SpawnSplash(Vector2 direction)
    {
        if (splashVFXPrefab == null)
            return;
        
        Quaternion splashRotation = Quaternion.LookRotation(direction, Vector3.back);
        Instantiate(splashVFXPrefab, transform.position, splashRotation);
    }
}
