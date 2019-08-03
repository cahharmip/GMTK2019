using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction
{
  LEFT,
  RIGHT
}

public class TurretController : MonoBehaviour
{
  public float speed = 0f;
  Rigidbody turretRigidbody;
  public Direction direction = Direction.LEFT;

  void Awake()
  {
    turretRigidbody = GetComponent<Rigidbody>();
  }

  void FixedUpdate()
  {
    Move();
  }

  void Move()
  {
    if (speed == 0f) return;
    Vector3 movement;
    if (direction == Direction.LEFT)
    {
      movement = transform.rotation * Quaternion.Euler(0, -90, 0) * Quaternion.Euler(0, -45, 0) * Vector3.one * speed * Time.deltaTime;
    }
    else
    {
      movement = transform.rotation * Quaternion.Euler(0,90, 0) * Quaternion.Euler(0, -45, 0) * Vector3.one * speed * Time.deltaTime;
    }
    turretRigidbody.velocity = movement;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Turret"))
    {
      if (direction == Direction.LEFT) direction = Direction.RIGHT;
      else if (direction == Direction.RIGHT) direction = Direction.LEFT;
    }
  }
}
