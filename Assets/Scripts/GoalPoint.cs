using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPoint : MonoBehaviour
{
  [SerializeField]
  private string _Stage;
  protected void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag.Equals("Player"))
    {
      SceneManager.LoadScene(_Stage);
    }
  }
}
