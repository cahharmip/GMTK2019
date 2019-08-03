using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGridNode : MonoBehaviour
{
    public WorldGridNode up;
    public WorldGridNode down;
    public WorldGridNode left;
    public WorldGridNode right;
    public string surface;
}

public enum WorldGridDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}