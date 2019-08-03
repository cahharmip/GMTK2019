using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    public Portal linkedPortal;

    private Dictionary<int, GameObject> _LaserList = new Dictionary<int, GameObject>();

    private const float OFFSET = 0.5f;
    public void Received(Vector3 hitPosition, Quaternion rayRotation)
    {
        Debug.Log("Received Laser", gameObject);
        Debug.Log("Forwarding Laser", linkedPortal.gameObject);
        Quaternion diff = transform.rotation * Quaternion.Inverse(linkedPortal.transform.rotation);
        rayRotation = diff * rayRotation;
        linkedPortal.LaserForward(gameObject.GetInstanceID(), hitPosition, rayRotation);
    }

    private void LaserForward(int id, Vector3 hitPosition, Quaternion rayRotation)
    {
        if (_LaserList.ContainsKey(id)) return;
        GameObject obj = ResourceLoadManager.LoadGameObject("Prefabs/BeamOrigin");
        _LaserList[id] = obj;
        if (obj != null)
        {
          GameObject newBeam = Instantiate(obj, hitPosition + transform.position, Quaternion.identity);
          //newBeam.transform.Translate(Vector3.forward * OFFSET);
          newBeam.transform.rotation = rayRotation;
        }
    }
}
