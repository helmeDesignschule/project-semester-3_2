using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AgentOverride2d))]
[RequireComponent(typeof(AgentRotate2d))]
public class Mover : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        //we know that the component has to be attached
        //to the same game object because we use RequireComponent.
        agent = GetComponent<NavMeshAgent>();
    }

    
    //can be called from anywhere to set a movement target.
    public void SetMovementTarget(Vector2 position)
    {
        agent.isStopped = false;
        agent.SetDestination(position);
    }
    
    //stops the current movement.
    public void CancelMovement()
    {
        agent.isStopped = true;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}
