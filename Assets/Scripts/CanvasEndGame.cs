using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasEndGame : MonoBehaviour
{
  IEnumerator Start()
  {
    float time = 0;
    while (time < 3f)
    {
      time += Time.deltaTime;
      float fraction = 1 - Mathf.Pow(2, -(10 * (time / 3f)));
      GetComponent<CanvasGroup>().alpha = fraction;
      yield return null;
    }
    GetComponent<CanvasGroup>().alpha = 1;
  }
}
