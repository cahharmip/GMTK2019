using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
  private void Start()
  {
    RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);
    foreach (RaycastHit hit in hits)
    {
      LineRenderer line = Instantiate(ResourceLoadManager.LoadGameObject("Prefabs/LaserBeam"), transform.position, Quaternion.identity).GetComponent<LineRenderer>();
      line.SetPosition(1, hit.collider.transform.position);
      if (hit.collider.tag.Equals("Wall"))
      {
        Transform wall = hit.collider.transform;
        Vector3 localHitPosition = hit.point - wall.position;
        Debug.DrawRay(transform.position, hit.collider.transform.position, Color.red, 1000f);
        wall.GetComponent<Portal>().Received(localHitPosition);
      }
      else if (hit.collider.tag.Equals("Player"))
      {
        Debug.Log("You're ded.");
      }
      else
      {
        Debug.Log("Me ending..");
        break;
      }
    }
  }
}
