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
        // Transform portal = hit.collider.transform;
        // Transform nextPortal = portal.GetComponent<Portal>().linkedPortal.transform;
        Vector3 nextStart = hit.point;
        Vector3 nextDirection = Vector3.Reflect(direction, hit.transform.up);

        Debug.Log("Reflected: " + direction + " to " + nextDirection);

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
        Debug.Log("<color=red>You're ded. noob xD</color>");
      }
      else if (hit.collider.tag.Equals("GlassWall"))
      {
        laser.positionCount = laserVertices + 1;
        laser.SetPosition(laserVertices++, start + direction * 3f);
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
