using Photon.Voice;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveDemoAvt : MonoBehaviour
{
    public GameObject demoAvt;
    
    public void RemoveDemoAvatar()
    {
        Destroy(demoAvt);
    }
}
