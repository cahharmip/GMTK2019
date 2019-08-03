using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovementController : MonoBehaviour
{
    [SerializeField]
    private WorldGridController world;

    private WorldGridNode node;

    private void Start()
    {
        node = world.root;
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
					if (node.right != null) node = node.right;
        } else if (Input.GetKeyDown(KeyCode.A))
				{
					if (node.left != null) node = node.left;
				}
				if (Input.GetKeyDown(KeyCode.W))
        {
					if (node.up != null) node = node.up;
        } else if (Input.GetKeyDown(KeyCode.S))
				{
					if (node.down != null) node = node.down;
				}
				transform.position = node.transform.position;
    }
}
