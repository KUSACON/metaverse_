using Fusion.XR.Shared.Desktop;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class teleportControl : MonoBehaviour
{
    MouseTeleport mouseTeleport;

    private void Start()
    {
        mouseTeleport = GetComponent<MouseTeleport>();
        mouseTeleport.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            mouseTeleport.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            mouseTeleport.enabled = false;
        }

    }

}
