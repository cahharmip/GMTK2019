using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
  [SerializeField]
  private Portal _LinkedPortal;

  private Dictionary<int, GameObject> _LaserList = new Dictionary<int, GameObject>();

  private const float OFFSET = 0.5f;
  public void Received(Vector3 hitPosition)
  {
    _LinkedPortal.LaserForward(gameObject.GetInstanceID(), hitPosition);
  }

  private void LaserForward(int id, Vector3 hitPosition)
  {
    if (_LaserList.ContainsKey(id)) return;
    GameObject obj = ResourceLoadManager.LoadGameObject("Prefabs/BeamOrigin");
    _LaserList[id] = obj;
    if (obj != null) Instantiate(obj, hitPosition + transform.position + new Vector3(0,0,OFFSET), Quaternion.identity);
  }
}
