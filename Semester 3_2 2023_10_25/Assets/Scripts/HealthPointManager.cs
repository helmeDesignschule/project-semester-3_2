using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPointManager : MonoBehaviour
{
    [SerializeField] private int maximumHealthPoints = 10;
    private int currentHealthPoints;

    private void Awake()
    {
        currentHealthPoints = maximumHealthPoints;
    }

    public void DealDamage(int amount)
    {
        currentHealthPoints -= amount;
        if (currentHealthPoints <= 0)
            Destroy(gameObject);
    }
}
