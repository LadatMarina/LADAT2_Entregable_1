using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Vector3 moveDirection;

    private Vector3Int upRightDirection = new Vector3Int(1, 1, 0);
    private Vector3Int upLeftDirection = new Vector3Int(-1, 1, 0);

    private float time = 0;
    private int timeMax = 1;
    
    void Start()
    {
        //set default direction
        moveDirection = upRightDirection;
    }

    void Update()
    {
        Timer();

        if (Input.GetKeyDown(KeyCode.E))
        {
            CanIMove(upRightDirection);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CanIMove(upLeftDirection); 
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CanIMove(-upRightDirection); 
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            CanIMove(-upLeftDirection); 
        }
    }

    
    //The Timer function moves moves the player every timeMax seconds
    private void Timer()
    {
        time += Time.deltaTime;
        if(time >= timeMax)
        {
            transform.Translate(moveDirection);
            time -= timeMax; //reset time value

        }
    } 
  
    /*The CanIMove function checks if the previous direction
     * is the oposit direction that the player wants to move at.
     */
    private void CanIMove(Vector3Int directionToMove)
    {
        if(-moveDirection != directionToMove)
        {
            moveDirection = directionToMove;
        }
        else
        {
            int alternativeMovement;
            alternativeMovement = Random.Range(0, 2); 

            if(alternativeMovement == 0)
            {
                moveDirection = new Vector3((moveDirection.x * -1),moveDirection.y,0);
            }
            if(alternativeMovement == 1)
            {
                moveDirection = new Vector3((moveDirection.x), moveDirection.y * -1, 0);
            }
        }
    }
}
