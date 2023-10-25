using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverBase : MonoBehaviour
{
    //returns the mover position
    public Vector2 GetPosition()
    {
        return transform.position;
    }
}
