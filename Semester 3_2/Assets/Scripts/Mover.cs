using System;
using System.Collections;
using System.Collections.Generic;
using NavMeshPlus.Extensions;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(AgentOverride2d))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Mover : MoverBase
{
    [SerializeField] private float radius = .5f;
    [SerializeField] private Transform body;
    
    private NavMeshAgent agent;

    private void Awake()
    {
        //we know that the component has to be attached
        //to the same game object because we use RequireComponent.
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
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

    

    public float GetRadius()
    {
        return radius;
    }

    private void OnValidate()
    {
        GetComponent<CircleCollider2D>().radius = radius;
        GetComponent<NavMeshAgent>().radius = radius;
        GetComponent<NavMeshAgent>().height = 0;
        if (body != null)
            body.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
    }
    
    
}
