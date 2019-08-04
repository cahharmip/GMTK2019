﻿using System.Collections;
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

  void Awake()
  {
    _currentDirection = transform.right;
    CalculateNewTargetPosition();
  }

  void Update()
  {
    Move();
  }

  void Move()
  {
    float distCovered = (Time.time - _startTime) * speed;
    float fracJourney = distCovered / _journeyLength;
    transform.position = Vector3.Lerp(_startMarker, _targetPosition, fracJourney);
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag.Equals("Wall") || collision.gameObject.tag.Equals("Turret"))
    {
      _currentDirection = -_currentDirection;
      CalculateNewTargetPosition();
    }
  }

  public void Jump()
  {
    CalculateNewTargetPosition();
  }
  private void CalculateNewTargetPosition()
  {
    _startTime = Time.time;
    _targetPosition = transform.position + (_currentDirection.normalized * step);
    _startMarker = transform.position;
    _journeyLength = Vector3.Distance(transform.position, _targetPosition);

  }
}
