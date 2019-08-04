using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  private Vector3 _CurrentPosition;
  private Vector3 _CurrentHitPoint;
  private LineRenderer laser;
  private int laserVertices;

  private void Start()
  {
    GameObject lineObj = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/LaserBeam"), transform.position, Quaternion.identity);
    laser = lineObj.GetComponent<LineRenderer>();
  }

  private void Update()
  {
    CastLaser();
    // Physics.Raycast(transform.position, transform.forward, out RaycastHit hit);
    // if (hit.collider)
    // {
    //     // if (_CurrentPosition != transform.position || _CurrentHitPoint != hit.point)
    //     // {
    //     //     if (_CurrentBeam != null) Destroy(_CurrentBeam);
    //     //     GameObject lineObj = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/LaserBeam"), transform.position, Quaternion.identity);
    //     //     LineRenderer line = lineObj.GetComponent<LineRenderer>();
    //     //     line.SetPosition(0, transform.position);
    //     //     line.SetPosition(1, hit.point);
    //     //     _CurrentPosition = transform.position;
    //     //     _CurrentHitPoint = hit.point;
    //     //     _CurrentBeam = lineObj;
    //     // }

    //     if (hit.collider.tag.Equals("Wall"))
    //     {
    //         Transform wall = hit.collider.transform;
    //         Vector3 localHitPosition = hit.point - wall.position;
    //         Quaternion rayRotation = transform.rotation;
    //         wall.GetComponent<Portal>().Received(localHitPosition, rayRotation);
    //     }
    //     else if (hit.collider.tag.Equals("Player"))
    //     {
    //         Debug.Log("<color=red>You're ded. noob xD</color>");
    //     }
    // }
  }

  private void CastLaser()
  {
      laserVertices = 0;
      laser.SetPosition(laserVertices++, transform.position);
      CastLaser(transform.position, transform.forward, 25);
  }

  private void CastLaser(Vector3 start, Vector3 direction, int limit)
  {
    if (limit == 0) return;
    Physics.Raycast(start, direction, out RaycastHit hit);
    if (hit.collider)
    {
      if (hit.collider.tag.Equals("Wall"))
      {
        // Transform portal = hit.collider.transform;
        // Transform nextPortal = portal.GetComponent<Portal>().linkedPortal.transform;
        Vector3 nextStart = hit.point;
        Vector3 nextDirection = Vector3.Reflect(direction, hit.transform.up);

        Debug.Log("Reflected: " + direction + " to " + nextDirection);

        laser.positionCount = laserVertices + 1;
        laser.SetPosition(laserVertices++, hit.point);

        limit -= 1;
        CastLaser(nextStart, nextDirection, limit);
      }
      else if (hit.collider.tag.Equals("Player"))
      {
        Debug.Log("<color=red>You're ded. noob xD</color>");
      }
    }
    else
    {
      laser.positionCount = laserVertices + 1;
      laser.SetPosition(laserVertices++, start + direction * 10f);
    }
  }
}
