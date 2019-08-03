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
      if (hit.collider.tag.Equals("Wall"))
      {
        Transform wall = hit.collider.transform;
        Vector3 localHitPosition = hit.point - wall.position;
        Debug.DrawRay(transform.position, hit.collider.transform.position, Color.red, 1000f);
        // Send signal to adjacent wall in order to generate the laser ray in next room
        wall.GetComponent<Portal>().Received(localHitPosition);
      }
      else
      {
        Debug.Log("Me ending..");
        break;
      }
    }
  }
}
