using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTurrentSync : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject[] turrets;

    TurretController[] tCtrl;
    float lastTrigger = 0;

    void Start()
    {
        tCtrl = new TurretController[turrets.Length];
        for (int i =0;i< turrets.Length; i++)
        {
            tCtrl[i] = turrets[i].GetComponent<TurretController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        float timing = audioSource.time;

        if(timing-lastTrigger >= 0.875)
        {
            AllJump();
            lastTrigger = timing;
        }
    }

    void AllJump()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            tCtrl[i].Jump();
        }
    }
}
