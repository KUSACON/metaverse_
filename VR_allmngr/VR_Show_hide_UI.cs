using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Show_hide_UI : MonoBehaviour
{
    public GameObject _VR_UI;
    public GameObject OVR_setup;

    bool R_TriggerPrevState = false;

    private void Start()
    {
        //_VR_UI.SetActive(false);
        //OVR_setup.SetActive(false);
    }

    void Update()
    {
        return;
        if (!static_val.isInVR)
        {
            return;
        }

        // Check for index trigger press on the left and right controllers
        bool leftTriggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f;
        bool rightTriggerPressed = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f;

        // If both triggers are pressed
        if (rightTriggerPressed )
        {
            if (R_TriggerPrevState)
                return;

            R_TriggerPrevState = true;
            //Debug.Log("Both index triggers are pressed!");
            // You can fill in more actions here
            _VR_UI.SetActive(!_VR_UI.activeSelf);
            OVR_setup.SetActive(_VR_UI.activeSelf);

        }
        else
        {
            R_TriggerPrevState = false;
        }

        /*// p is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            _VR_UI.SetActive(!_VR_UI.activeSelf);
            OVR_setup.SetActive(_VR_UI.activeSelf);

        }*/

    }
}
