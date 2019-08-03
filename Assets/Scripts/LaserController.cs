using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  private Vector3 _CurrentPosition;
  private Vector3 _CurrentHitPoint;
  private GameObject _CurrentBeam;
  private void Update()
  {
    Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
    if (hit.collider)
    {
      if (_CurrentPosition != transform.position || _CurrentHitPoint != hit.point)
      {
        if (_CurrentBeam != null) Destroy(_CurrentBeam);
        GameObject lineObj = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/LaserBeam"), transform.position, Quaternion.identity);
        LineRenderer line = lineObj.GetComponent<LineRenderer>();
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hit.point);
        _CurrentPosition = transform.position;
        _CurrentHitPoint = hit.point;
        _CurrentBeam = lineObj;
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
