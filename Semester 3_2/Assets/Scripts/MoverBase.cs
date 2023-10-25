using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBase : MonoBehaviour
{
    private Vector2 lookDirection;
    
    //returns the mover position
    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public Vector2 GetLookDirection()
    {
        return lookDirection;
    }

    public void SetLookDirection(Vector2 newLookDirection)
    {
        lookDirection = newLookDirection;
    }
}
