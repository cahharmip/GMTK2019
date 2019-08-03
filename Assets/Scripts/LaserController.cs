using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private void Update()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag.Equals("Wall"))
            {
                Transform wall = hit.collider.transform;
                Vector3 localHitPosition = hit.point - wall.position;

								// Send signal to adjacent wall in order to generate the laser ray in next room
                Debug.Log(localHitPosition);
            }
        }
    }
}
