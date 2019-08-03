using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
  [SerializeField]
  private Portal _LinkedPortal;

  private const float OFFSET = 0.5f;
  public void Received(Vector3 hitPosition)
  {
    Debug.Log("recieved");
    _LinkedPortal.LaserForward(hitPosition);
  }

  private void LaserForward(Vector3 hitPosition)
  {
    GameObject obj = ResourceLoadManager.LoadGameObject("Prefabs/BeamOrigin");
    if (obj != null) Instantiate(obj, hitPosition + transform.position + new Vector3(0,0,OFFSET), Quaternion.identity);
  }
}
