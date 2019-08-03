using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstrucleBase : MonoBehaviour
{
  protected void OnCollisionEnter(Collision col)
  {
    Debug.Log("Hey I'm just touched by " + col.gameObject.name + " senpai~~ Kiya");
    gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
  }
}
