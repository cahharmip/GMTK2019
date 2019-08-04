﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public Vector3 doorMovement = new Vector3(0, 0, 0.15f);
    public GameObject[] turrets;
    TurretController[] tCtrl;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        tCtrl = new TurretController[turrets.Length];
        for (int i = 0; i < turrets.Length; i++)
        {
            tCtrl[i] = turrets[i].GetComponent<TurretController>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider cd)
    {
        Debug.Log("enter");
        if(door1 != null)
        {
            door1.transform.position += doorMovement;
        }
        if(door2 != null)
        {
            door2.transform.position += doorMovement;
        }
        if(turrets.Length > 0)
        {
            AllShouldJump();
        }
    }

    //void OnTriggerExit(Collider cd)
    //{
    //    Debug.Log("exit");
    //    if (door != null)
    //    {
    //        door.transform.position -= doorMovement;
    //    }
    //}

    void AllShouldJump()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            tCtrl[i].shouldJump = true;
        }
    }
}
