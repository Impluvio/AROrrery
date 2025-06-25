using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject targetToFollow;
    private Transform transformOfTarget;

    // Update is called once per frame
    void Update()
    {
        transformOfTarget = targetToFollow.transform;

        if(targetToFollow != null)
        {
            transform.LookAt(transformOfTarget);
        }
    }
}
