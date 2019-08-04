using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTurrentSync : MonoBehaviour
{
    //public AudioSource audioSource;
    public GameObject[] turrets;
    public GameObject[] blocks;

    TurretController[] tCtrl;
    BlockController[] bCtrl;
    float lastTrigger = 0;

    void Start()
    {
        tCtrl = new TurretController[turrets.Length];
        for (int i =0;i< turrets.Length; i++)
        {
            tCtrl[i] = turrets[i].GetComponent<TurretController>();
        }

        bCtrl = new BlockController[blocks.Length];
        for (int i = 0; i < blocks.Length; i++)
        {
            bCtrl[i] = blocks[i].GetComponent<BlockController>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        float timing = Time.time;

        if(timing-lastTrigger >= 0.857125)
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
        for (int i = 0; i < bCtrl.Length; i++)
        {
            bCtrl[i].Jump();
        }

        
    }
}
