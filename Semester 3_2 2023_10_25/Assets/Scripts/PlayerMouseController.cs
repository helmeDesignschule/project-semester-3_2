using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseController : MonoBehaviour
{
    [SerializeField] private Mover mover;
    
    private void Update()
    {
        //check if left mouse button is held down
        if (Input.GetMouseButton(0))
        {
            //Input.mousePosition is saved in screenspace pixel coordinates, so we have to convert that to world coordinates.
            Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //when setting the destination, the agent will search a path and start moving towards that position
            mover.SetMovementTarget(mouseWorldPosition);
        }

        if (Input.GetMouseButton(1))
        {
            mover.CancelMovement();
        }
    }

}
