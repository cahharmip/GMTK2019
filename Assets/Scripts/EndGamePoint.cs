using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePoint : MonoBehaviour
{
  protected void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.name.Equals("Player"))
    {
      Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/CanvasEndLastStage"));
    }
  }
}
