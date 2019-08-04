using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  enum Direction
{
  LEFT,
  RIGHT,
  UP,
  DOWN
}

public class TurretController : MonoBehaviour
{
  public float speed = 100f;
  public float step = 1f;
  public string moveSet;
  private Direction[] moves;
  private int _moveIdx = -1;
  private Vector3 _currentDirection;
  private Vector3 _targetPosition;
  private Vector3 _startMarker;
  private float _startTime;
  private float _journeyLength;
  private bool _started = false;

  private void Start()
  {
    GenerateMoveset();
  }

  void GenerateMoveset()
  {
    moves = new Direction[moveSet.Length];
    for (int i = 0; i < moveSet.Length; i++)
    {
      char move = moveSet[i];
      switch (move)
      {
        case 'L':
          moves[i] = Direction.LEFT;
          break;
        case 'R':
          moves[i] = Direction.RIGHT;
          break;
        case 'U':
          moves[i] = Direction.UP;
          break;
        case 'D':
          moves[i] = Direction.DOWN;
          break;
      }
    }
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

  public void Jump()
  {
    CalculateNewTargetPosition();
  }
  private void CalculateNewTargetPosition()
  {
    _moveIdx += 1;
    if (_moveIdx == moves.Length)
    {
      _moveIdx = 0;
    }
    switch (moves[_moveIdx])
    {
      case Direction.LEFT:
        _currentDirection = -transform.right;
        break;
      case Direction.RIGHT:
        _currentDirection = transform.right;
        break;
      case Direction.UP:
        _currentDirection = transform.forward;
        break;
      case Direction.DOWN:
        _currentDirection = -transform.forward;
        break;
    }
    _started = true;
    _startTime = Time.time;
    _targetPosition = transform.position + (_currentDirection.normalized * step);
    _startMarker = transform.position;
    _journeyLength = Vector3.Distance(transform.position, _targetPosition);

  }
}
