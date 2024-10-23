using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BlockColoringManager))]

public class BlockCreateManager : MonoBehaviour
{
    private BlockColoringManager blockColoringManager;
    [SerializeField] int blockCount = 10;
    [SerializeField] float gapX = 1.5f;
    [SerializeField] float initialY = 0.5f;
    [SerializeField] float gapZ = 1.0f;

    private void Awake()
    {
        blockColoringManager = GetComponent<BlockColoringManager>();
    }

    void Start()
    {
        blockColoringManager.FillColors();
        blockColoringManager.CreateColorList();
        blockColoringManager.Shuffle();

        for (int i = 0; i < blockCount; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

            if (i < blockCount / 2)
            {
                cube.transform.position = new Vector3(i * gapX, initialY, gapZ);
            }
            else
            {
                int temp = i % (blockCount / 2);

                cube.transform.position = new Vector3(temp * gapX, initialY, -gapZ);
            }

            Renderer renderer = cube.GetComponent<Renderer>();
            
            if (renderer != null)
            {
                renderer.material.color = blockColoringManager.Lists[i];
            }
        }
    }
}