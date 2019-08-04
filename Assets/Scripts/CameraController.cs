using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraParent;

    [SerializeField]
    [Range(0f, 1f)]
    private float animationDuration;

    private bool isRotating = false;

    private void Update()
    {
        if (Input.GetButton("RotateLeft"))
        {
            RotateLeft();
        }
        else if (Input.GetButton("RotateRight"))
        {
            RotateRight();
        }
    }

    public void RotateLeft()
    {
        if (!isRotating) StartCoroutine(Rotate(90f));
    }

    public void RotateRight()
    {
        if (!isRotating) StartCoroutine(Rotate(-90f));
    }

    private IEnumerator Rotate(float amount)
    {
        isRotating = true;
        Quaternion from = cameraParent.rotation;
        Quaternion to = cameraParent.rotation * Quaternion.Euler(0f, amount, 0f);
        float time = 0f;
        while ( time < animationDuration )
        {
            float t = time / animationDuration;
            cameraParent.rotation = Quaternion.Lerp(from, to, t);
            time += Time.deltaTime;
            yield return null;
        }
        cameraParent.rotation = to;
        isRotating = false;
    }
}
