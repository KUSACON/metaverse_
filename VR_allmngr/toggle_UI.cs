using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class toggle_UI : MonoBehaviour
{
    public GameObject canvas;
    //public List<GameObject> ui_canvas = new List<GameObject>();
    //public GameObject VR_setup;
    private bool gripWasPressed = false; // Track the previous grip button state



    private void Update()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightHandedCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightHandedCharacteristics, devices);

        /*
        if (devices.Count > 0)
        {
            InputDevice device = devices[0];
            
            //if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.5f)
            if (device.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.5f)
            {
                canvas.SetActive(true);
               // VR_setup.SetActive(true);
            }
            else
            {
                canvas.SetActive(false);
               // VR_setup.SetActive(false);
            }


        }
        */

        if (devices.Count > 0)
        {
            InputDevice device = devices[0];

            if (device.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
            {
                if (gripValue > 0.5f && !gripWasPressed) // Grip is pressed and it wasn't pressed the last frame
                {
                    gripWasPressed = true; // Update the grip state
                    canvas.SetActive(!canvas.activeSelf); // Toggle the active state of the canvas


                }
                else if (gripValue <= 0.5f)
                {
                    gripWasPressed = false; // Update the grip state
                }
            }
        }
    }

    #region extra
    /*
    // Update is called once per frame
    void tt_Update()
    {
        if (!static_val.isInVR)
        {
            return;
        }

        bool leftTriggerPressed = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f;
        bool rightTriggerPressed = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f;

        if (rightTriggerPressed)
        {
            DemoGO.SetActive(true);
        }
        else
        {
            DemoGO.SetActive(false);
        }

    }

    private void ssUpdate()
    {
        if (!static_val.isInVR)
        {
            return;
        }


        //do same for input action 
        if (oculus_trigger.action.ReadValue<float>() == 1)
        {
            DemoGO.SetActive(true);
        }
        else
        {
            DemoGO.SetActive(false);
        }

        Debug.Log("trigger value: " + oculus_trigger.action.ReadValue<float>());

        textMesh.text = "trigger value: " + oculus_trigger.action.ReadValue<float>();



    }
    */
    #endregion

}
