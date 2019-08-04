using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 1f;
  Vector3 movement;
  Rigidbody playerRigidbody;

  void Awake()
  {
    playerRigidbody = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    Move(h, v);
  }

  void Move(float h, float v)
  {
    movement.Set(h, 0f, v);
    float camRot = Camera.main.transform.rotation.eulerAngles.y;
    movement = Quaternion.Euler(0, camRot, 0) * movement.normalized * speed * Time.deltaTime;
    playerRigidbody.velocity = movement;
  }
}