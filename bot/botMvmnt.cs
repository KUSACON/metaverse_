using Fusion.Addons.LocomotionValidation;
using Fusion.XR.Shared.Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botMvmnt : MonoBehaviour
{
    public GameObject desktopCon;

    // Start is called before the first frame update
    void Start()
    {
        if(static_val._characterType == 3)
        {
            desktopCon.transform.position = transform.position;
            desktopCon.transform.rotation = transform.rotation;
            FindObjectOfType<LocomotionValidatedDesktopController>().enabled = false;
            FindObjectOfType<RigLocomotion>().enabled = false;
        }
        else
        {
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
