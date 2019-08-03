using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  public float speed = 1f;
  Vector3 movement;
  Rigidbody playerRigidbody;

  void Awake () {
    playerRigidbody = GetComponent<Rigidbody> ();
  }

  void FixedUpdate () {
    float h = Input.GetAxisRaw("Horizontal");
    float v = Input.GetAxisRaw("Vertical");
    Move(h, v);
  }

  void Move(float h, float v)
  {
    movement.Set(h, 0f, v);
    movement = Quaternion.Euler(0, -45, 0) * movement.normalized * speed * Time.deltaTime;
    playerRigidbody.MovePosition(transform.position + movement);
  }
}