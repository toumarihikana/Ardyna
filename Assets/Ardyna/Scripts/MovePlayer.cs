using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;
    [SerializeField] private AnimationCurve moveSpeedCurve;
    [SerializeField] private GameObject enemyObject;

    [SerializeField] private bool isMoveing;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private float startTime;

    [SerializeField]float progressTime;
    float movedTime = 0.2f;



    [SerializeField] float baseTheta;
    [SerializeField] float defaultMoveTheta = 40f;
    [SerializeField] float baseR;
    [SerializeField] float defaultMoveR = 3f;
    [SerializeField] float minimumR = 2f;
    public void MoveHorizontal(Vector2 direction)
    {
        if (!isMoveing)
        {
            Debug.Log(direction);
            startPosition = playerObject.transform.position;

            Vector2 posA = new Vector2(startPosition.x, startPosition.z);
            Vector2 posB = new Vector2(enemyObject.transform.position.x, enemyObject.transform.position.z);

            baseR = Vector2.Distance(posB, posA);

            //floatの誤差を消すためにRoundしている
            baseTheta = Mathf.Round(Mathf.Atan2(startPosition.z, startPosition.x) * Mathf.Rad2Deg);

            //左右への移動
            if (direction.x != 0)
            {
                float addTheta = defaultMoveTheta * Mathf.Sign(direction.x);

                Vector2 pos3 = CoordinateTransform.PolarToCartesian2D(posB, baseR, addTheta + baseTheta);            
            
                endPosition.x = pos3.x;
                endPosition.y = startPosition.y;
                endPosition.z = pos3.y;

            }
            //原点を超えて前進しない様にする
            else if (baseR <= minimumR && Math.Sign(direction.y) == 1)
            {
                return;
            }
            //前後への移動
            else
            {
                float addR = defaultMoveR * Mathf.Sign(direction.y) * -1;

                Vector2 pos3 = CoordinateTransform.PolarToCartesian2D(posB, addR + baseR, baseTheta);

                endPosition.x = pos3.x;
                endPosition.y = startPosition.y;
                endPosition.z = pos3.y;

            }

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
