using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class StageOneController : MonoBehaviour
{
  [SerializeField]
  private CinemachineBrain cinemachine;

  public enum State
  {
    Intro,
    Play,
    Pause,
  }

  public static State Stage = State.Intro;
  protected void Awake()
  {
    //Do some wow animation
  }
}
