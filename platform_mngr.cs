using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform_mngr : MonoBehaviour
{
    public enum Platform
    {
        PC,
        Android,
        WebGL
    }

    public Platform platform = Platform.PC;

    private void Awake()
    {
        if (platform == Platform.PC)
        {

        }
        else if (platform == Platform.WebGL)
        {

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
