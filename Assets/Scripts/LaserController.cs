using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  private void Update()
  {
    Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
    if (hit.collider)
    {
      LineRenderer line = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/LaserBeam"), transform.position, Quaternion.identity).GetComponent<LineRenderer>();
      line.SetPosition(0, transform.position);
      line.SetPosition(1, hit.point);
    }
     if (hit.collider.tag.Equals("Wall"))
     {
       Transform wall = hit.collider.transform;
       Vector3 localHitPosition = hit.point - wall.position;
       wall.GetComponent<Portal>().Received(localHitPosition);
     }
     else if (hit.collider.tag.Equals("Player"))
     {
       Debug.Log("<color=red>You're ded. noob xD</color>");
     }
     else
     {
       Debug.Log("Me ending..");
     }
  }
}
