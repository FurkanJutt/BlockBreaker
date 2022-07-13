using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // Configuration Paramaters
    [SerializeField] int brakeableBlocks; // Serialized for debugging

    // Cached Reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakAbleBlocks()
    {
        brakeableBlocks++;
    }

    public void BlockDestroyed()
    {
        brakeableBlocks--;
        if (brakeableBlocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
}
