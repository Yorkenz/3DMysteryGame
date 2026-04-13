using System.Collections;
using System.Collections.Generic;   
using UnityEngine;

public class WanderAi : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float rotSpeed = 5f;

    private bool isWandering = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isWalking = false;
    private int rotateLorR;



    void Update()
    {
        if (isWandering == false)
        {
            StartCoroutine(Wander());
        }
        if (isRotatingRight == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotSpeed);
            Debug.Log("Rotating Right");
        }
        if (isRotatingLeft == true)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotSpeed);
            Debug.Log("Rotating Left");
        }
        if (isWalking == true)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            Debug.Log("Walking");
        }

    }
    IEnumerator Wander()
    {
        int rotTime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 4);
        int walkWait = Random.Range(1, 4);
        int walkTime = Random.Range(1, 5);
        isWandering = true;
        yield return new WaitForSeconds(rotateWait);
        isRotatingRight = true;
        yield return new WaitForSeconds(rotTime);
        isRotatingRight = false;
        yield return new WaitForSeconds(walkWait);
        isWalking = true;
        yield return new WaitForSeconds(walkTime);
        isWalking = false;
        yield return new WaitForSeconds(rotateWait);
        if (rotateLorR == 1)
        {
            isRotatingRight = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingRight = false;
        }
        if (rotateLorR == 2)
        {
            isRotatingLeft = true;
            yield return new WaitForSeconds(rotTime);
            isRotatingLeft = false;
        }
        isWandering = false;
    }
}
