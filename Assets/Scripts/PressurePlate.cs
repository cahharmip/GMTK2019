using System.Collections;
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
    if (turrets.Length > 0)
    {
    tCtrl = new TurretController[turrets.Length];
    for (int i = 0; i < turrets.Length; i++)
    {
      tCtrl[i] = turrets[i].GetComponent<TurretController>();
    }
    }
  }

  void OnTriggerEnter(Collider cd)
  {
    Debug.Log("enter");
    this.gameObject.SetActive(false);
        if(door1 != null)
        {
            door1.transform.position += doorMovement;
        }
        if(door2 != null)
        {
            door2.transform.position += doorMovement;
        }
        if(tCtrl != null)
        {
            AllShouldJump();
        }
  }

  void AllShouldJump()
  {
    for (int i = 0; i < tCtrl.Length; i++)
    {
            tCtrl[i].shouldJump = true;
    }
  }
}
