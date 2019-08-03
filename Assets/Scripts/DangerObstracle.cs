using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerObstracle : ObstracleBase
{
  public override void OnCollisionEvent(Collision col)
  {
    if (col.gameObject.name.Equals("Player"))
    {
      col.gameObject.GetComponent<Renderer>().material.color = new Color(1,0,0);
      Debug.Log("<color=red>You're so ded man....</color>");
    }
  }
}
