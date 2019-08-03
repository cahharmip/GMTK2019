using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  private Vector3 _CurrentPosition;
  private Vector3 _CurrentHitPoint;

  private void Update()
  {
    Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
    if (hit.collider)
    {
      if (_CurrentPosition != transform.position || _CurrentHitPoint != hit.point)
      {
        LineRenderer line = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/LaserBeam"), transform.position, Quaternion.identity).GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hit.point);
        _CurrentPosition = transform.position;
        _CurrentHitPoint = hit.point;
      }
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
  }
}
