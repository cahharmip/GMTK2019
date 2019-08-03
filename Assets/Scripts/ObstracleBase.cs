using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObstracleBase : MonoBehaviour
{
  protected void OnCollisionEnter(Collision col)
  {
    gameObject.GetComponent<Renderer>().material.color = new Color(0.4f,0f,0f);
    OnCollisionEvent(col);
  }

  public abstract void OnCollisionEvent(Collision col);
}
