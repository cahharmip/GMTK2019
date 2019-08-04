using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
  public float speed = 0f;
  private Vector3 _CurrentDirection;

  void Awake()
  {
    _CurrentDirection = transform.right;
  }

  void FixedUpdate()
  {
    Move();
  }

  void Move()
  {
    transform.position += _CurrentDirection * speed * Time.deltaTime;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Turret"))
    {
      _CurrentDirection = -_CurrentDirection;
    }
  }
}
