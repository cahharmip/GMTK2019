using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    Vector3 doorMovement = new Vector3(0, 0, 0.15f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider cd)
    {
        door.transform.position += doorMovement;
        Debug.Log("enter");
    }

    void OnTriggerExit(Collider cd)
    {
        door.transform.position -= doorMovement;
        Debug.Log("exit");
    }
}
