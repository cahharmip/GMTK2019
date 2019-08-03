using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGridController : MonoBehaviour
{

    [SerializeField]
    private float worldSize;
    [SerializeField]
    private int sectionsPerEdge;

    private Transform worldParent;

    private WorldGridNode[][] upSurface;
    private WorldGridNode[][] downSurface;
    private WorldGridNode[][] leftSurface;
    private WorldGridNode[][] rightSurface;
    private WorldGridNode[][] forwardSurface;
    private WorldGridNode[][] backSurface;

    public WorldGridNode root;

    private Vector3 upRightFront;
    private Vector3 downLeftBack;

    [ContextMenu("Generate Grid")]
    private void GenerateGrid()
    {
        if (worldParent != null) DestroyImmediate(worldParent.gameObject);
        upRightFront = Vector3.one * worldSize;
        downLeftBack = Vector3.one * worldSize * -1f;
        worldParent = (new GameObject()).transform;
        worldParent.name = "WorldParent";
        upSurface = GenerateSurface(Vector3.up, "UP");
        leftSurface = GenerateSurface(Vector3.left, "LEFT");
        forwardSurface = GenerateSurface(Vector3.forward, "FORWARD");
        downSurface = GenerateSurface(Vector3.down, "DOWN");
        rightSurface = GenerateSurface(Vector3.right, "RIGHT");
        backSurface = GenerateSurface(Vector3.back, "BACK");
				StitchUpSurface();
				root = upSurface[0][0];
    }

    private WorldGridNode[][] GenerateSurface(Vector3 surfaceDirection, string name)
    {
        Transform surfaceParent = (new GameObject()).transform;
        surfaceParent.name = name;
        surfaceParent.parent = worldParent;
        float sectionSize = (upRightFront.x - downLeftBack.x) / (float)sectionsPerEdge;

        WorldGridNode[][] nodes = new WorldGridNode[sectionsPerEdge][];

        for (int i = 0; i < sectionsPerEdge; i++)
        {
            nodes[i] = new WorldGridNode[sectionsPerEdge];
            float x = downLeftBack.x + (sectionSize / 2f) + (i * sectionSize);
            for (int j = 0; j < sectionsPerEdge; j++)
            {
                float y = downLeftBack.y + (sectionSize / 2f) + (j * sectionSize);

                GameObject debug = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                debug.name = "Node: (" + i + "," + j + ")";
                debug.transform.position = new Vector3(x, y, 0f);
                debug.transform.localScale = Vector3.one * .1f;
                debug.transform.parent = surfaceParent;

                WorldGridNode node = debug.AddComponent<WorldGridNode>();
                nodes[i][j] = node;
            }
        }
        for (int i = 0; i < sectionsPerEdge; i++)
        {
            for (int j = 0; j < sectionsPerEdge; j++)
            {
                if (i - 1 >= 0) nodes[i][j].left = nodes[i - 1][j];

                if (i + 1 <= sectionsPerEdge - 1) nodes[i][j].right = nodes[i + 1][j];

                if (j - 1 >= 0) nodes[i][j].down = nodes[i][j - 1];

                if (j + 1 <= sectionsPerEdge - 1) nodes[i][j].up = nodes[i][j + 1];

            }
        }
        surfaceParent.LookAt(surfaceDirection);
        float toTranslate = ((upRightFront.x - downLeftBack.x) / 2f);
        surfaceParent.Translate(Vector3.forward * toTranslate);
        surfaceParent.LookAt(Vector3.zero);

        return nodes;
    }

    private void StitchUpSurface()
    {
        for (int i = 0; i < sectionsPerEdge; i++)
        {
            for (int j = 0; j < sectionsPerEdge; j++)
            {
                if (i == 0)
                {
                    upSurface[i][j].left = leftSurface[sectionsPerEdge - 1 - j][sectionsPerEdge - 1];
                    leftSurface[sectionsPerEdge - 1 - j][sectionsPerEdge - 1].up = upSurface[i][j];
                }
								if (i == sectionsPerEdge - 1)
								{
                    upSurface[i][j].right = rightSurface[i][sectionsPerEdge - 1];
                    rightSurface[i][sectionsPerEdge - 1].up = upSurface[i][j];
								}
								if (j == 0)
								{
                    upSurface[i][j].down = backSurface[i][sectionsPerEdge - 1];
                    backSurface[i][sectionsPerEdge - 1].up = upSurface[i][j];
								}
								if (j == sectionsPerEdge - 1)
								{
                    upSurface[i][j].up = forwardSurface[sectionsPerEdge - 1 - i][sectionsPerEdge - 1];
                    forwardSurface[sectionsPerEdge - 1 - i][sectionsPerEdge - 1].up = upSurface[i][j];
								}
            }
        }
    }

    private void LateUpdate()
    {
    }
}
