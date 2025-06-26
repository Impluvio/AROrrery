using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Camera arCamera;

    private void Start()
    {
        arCamera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        if (arCamera != null)
        {
            transform.LookAt(arCamera.transform); 


            //Vector3 direction = arCamera.transform.position - transform.position;

            ////direction.y = 0;

            //if (direction.sqrMagnitude > 0.001f)
            //{
            //    transform.rotation = Quaternion.LookRotation(direction);

            //}


        }
    }
}
