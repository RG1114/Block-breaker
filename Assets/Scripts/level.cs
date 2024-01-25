using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{
    //parameters
    [SerializeField] int breakableBlocks; //for debugging
    
    //cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader=FindObjectOfType<SceneLoader>();

    }


    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void ReduceBreakableBlock()
    {
        breakableBlocks--;
        if(breakableBlocks<=0)
        {
            sceneloader.LoadNextScene();
        }
    }
    
    
}
