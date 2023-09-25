using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Mover mover;
    [SerializeField] private Mover playerMover;
    
    void Update()
    {
        mover.SetMovementTarget(playerMover.GetPosition());
    }
}
