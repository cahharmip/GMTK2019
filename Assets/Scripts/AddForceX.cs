using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceX : MonoBehaviour
{
  // Start is called before the first frame update
  protected void Start()
  {
    gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-20f,0,0));
  }
}
