using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_UI_place : MonoBehaviour
{
    public GameObject _VR_UI;

    private void Update()
    {
        if (static_val.isInVR)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            _VR_UI.transform.position = transform.position;
        }
    }
}
