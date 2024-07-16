using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas_placement : MonoBehaviour
{
    public GameObject canvas;
    public GameObject Cam;
    public float scale = 0.0023f;

    // Update is called once per frame
    void Update()
    {
        canvas.transform.position = Cam.transform.position + Cam.transform.forward * 2.5f;
        //canvas.transform.rotation = Cam.transform.rotation;
        canvas.transform.localScale = new Vector3(scale, scale, scale);
        //copy roation buy not local z from camera
        canvas.transform.rotation = Quaternion.Euler(Cam.transform.rotation.eulerAngles.x, Cam.transform.rotation.eulerAngles.y, 0);

        
    }
}
