using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private AnimationCurve moveSpeedCurve;

    [SerializeField] private bool isMoveing;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime;

    [SerializeField]float progressTime;
    float movedTime = 0.2f;


    public void MoveHorizontal(Vector2 direction)
    {
        if (!isMoveing)
        {

            //Debug.Log(direction);
            startPosition = playerObject.transform.position;

            endPosition.x = startPosition.x + (direction.x * 5f);
            endPosition.y = startPosition.y;
            endPosition.z = startPosition.z + (direction.y * 5f);

            startTime = Time.time;
            if (!(direction.x == 0f && direction.y == 0f))
            {
                isMoveing = true;
            }
            

        }
    }

    void Update()
    {
        if (isMoveing)
        {
            progressTime = Time.time - startTime;
            float rate = progressTime / movedTime;
            var curvedRate = moveSpeedCurve.Evaluate(rate);
            playerObject.transform.position = Vector3.Lerp(startPosition, endPosition, curvedRate);
            if (curvedRate == 1)
            {
                isMoveing = false;
            }
        }
    }

}
