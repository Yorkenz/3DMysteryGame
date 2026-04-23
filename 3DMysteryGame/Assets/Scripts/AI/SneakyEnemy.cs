using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SneakyEnemy : MonoBehaviour
{
  public float rotationSpeed;

    void Update()
    {
        // Rotate the enemy around its Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
