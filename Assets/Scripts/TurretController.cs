using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
  public float speed = 100f;
  public float step = 1f;
  private Vector3 _currentDirection;
  private Vector3 _targetPosition;
  private Vector3 _startMarker;
  private float _startTime;
  private float _journeyLength;
  private bool _started = false;

  void Awake()
  {
    _currentDirection = transform.right;
  }

  void Update()
  {
    Move();
  }

  void Move()
  {
    if (!_started) return;
    float distCovered = (Time.time - _startTime) * speed;
    float fracJourney = distCovered / _journeyLength;
    transform.position = Vector3.Lerp(_startMarker, _targetPosition, fracJourney);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Turret"))
    {
      _currentDirection = -_currentDirection;
    }
  }

  public void Jump()
  {
    CalculateNewTargetPosition();
  }
  private void CalculateNewTargetPosition()
  {
    _started = true;
    _startTime = Time.time;
    _targetPosition = transform.position + (_currentDirection.normalized * step);
    _startMarker = transform.position;
    _journeyLength = Vector3.Distance(transform.position, _targetPosition);

  }
}
