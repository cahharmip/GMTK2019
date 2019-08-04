using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWorld : MonoBehaviour
{
    Transform theWorld;
    int speed = 100;
    bool rotateZ = false;
    float zTarget;
    // Start is calle before the first frame update
    void Start()
    {
        theWorld = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("y"))
        {
            rotateZ = true;
        }
        //if (Mathf.Abs( theWorld.rotation.eulerAngles.z - zTarget) <= 1f)
        //{
        //    Vector3 rot = theWorld.rotation.eulerAngles;
        //    rot.z = zTarget;
        //}
    }

    float angleClamp(float angle)
    {
        return Mathf.Repeat(angle, 360);
    }
}
