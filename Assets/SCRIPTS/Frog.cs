using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Vector3Int moveDirection;

    private Vector3Int upRightDirection = new Vector3Int(1, 1, 0);
    private Vector3Int upLeftDirection = new Vector3Int(-1, 1, 0);

    private float time = 0;
    private float timeMax = 0.1f;
    void Start()
    {
        moveDirection = upRightDirection;
    }

    void Update()
    {
        Timer2();

        if (Input.GetKeyDown(KeyCode.E))
        {
            CanIMove(upRightDirection); //UR
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            CanIMove(upLeftDirection); //UL
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            CanIMove(-upRightDirection); //-UR
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CanIMove(-upLeftDirection); //-UL
        }
    }

    /*private IEnumerator Timer()
    {
        while (time >= 0)
        {
            time += 0.1f;
            transform.Translate(moveDirection);
            new WaitForSeconds(0.1f);
        }
        return null;
    }*/

    private void Timer2()
    {
        time = +Time.deltaTime;

        if(time >= timeMax)
        {
            time -= timeMax; //reset time value
            transform.Translate(moveDirection);
        }
    } 
  
    private void CanIMove(Vector3Int directionToMove)
    {
        if(-moveDirection != directionToMove)
        {
            moveDirection = directionToMove;
        }
        else
        {
            int alternativeMovement;
            alternativeMovement = Random.Range(0, 1);
            Debug.Log(alternativeMovement);
            if(alternativeMovement == 0)
            {
                moveDirection = new Vector3Int((moveDirection.x * -1),moveDirection.y,0);
            }
            if(alternativeMovement == 1)
            {
                moveDirection = new Vector3Int((moveDirection.x), moveDirection.y * -1, 0);
            }
        }
    }
}
