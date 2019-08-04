using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  public bool showLaserOnMainPlane = false;
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
  }

  private void CastLaser()
  {
    laserVertices = 0;
    laser.SetPosition(laserVertices++, transform.position);
    CastLaser(transform.position, transform.forward, 5);
  }

  private void CastLaser(Vector3 start, Vector3 direction, int limit)
  {
    if (limit == 0) return;
    Physics.Raycast(start, direction, out RaycastHit hit, 200f, ~(1 << 9)); // layer 9 is Portal
    if (hit.collider)
    {
      if (hit.collider.tag.Equals("Reflector"))
      {
        Vector3 nextStart = hit.point;
        Vector3 nextDirection = Vector3.Reflect(direction, hit.transform.up);

        limit -= 1;

        if (limit > 0)
        {
          laser.positionCount = laserVertices + 1;
          laser.SetPosition(laserVertices++, hit.point);
        }

        CastLaser(nextStart, nextDirection, limit);
      }
      else if (hit.collider.tag.Equals("Player"))
      {
        hit.collider.gameObject.active = false;
        Debug.Log("<color=red>You're ded. noob xD</color>");
      }
      else
      {
        laser.positionCount = laserVertices + 1;
        laser.SetPosition(laserVertices++, hit.point);
      }
    }
    else
    {
      laser.positionCount = laserVertices + 1;
      laser.SetPosition(laserVertices++, start + direction * 10f);
    }
  }
}
