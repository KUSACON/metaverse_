using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penMngr : MonoBehaviour
{
    public float penpos = 0;
    public bool in_X = false;
    public bool in_Z = false;

    public Vector3 def_pos = new Vector3(0, 0, 0);
    public Vector3 def_Rot = new Vector3(0, 0, 0);


    private void Start()
    {
        def_pos = transform.localPosition;
        def_Rot = transform.localRotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (in_X)
            pos.x = penpos;
        if (in_Z)
            pos.z = penpos;
        
        //transform.position = pos;
        transform.localPosition = def_pos;
        transform.localRotation = Quaternion.Euler(def_Rot);
    }
}
