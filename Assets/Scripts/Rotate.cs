using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    GameObject planetToRotate;

    void Start()
    {
        planetToRotate = gameObject; 
    }

    // Update is called once per frame
    void Update()
    {
        planetToRotate.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
