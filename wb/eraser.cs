using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eraser : MonoBehaviour
{
    public List<GameObject> PenStrokes = new List<GameObject>();
    

    // Update is called once per frame
    void Update()
    {
        //if input key p is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i =0; i < PenStrokes.Count; i++)
            {
                if (PenStrokes[i])
                {
                    Destroy(PenStrokes[i]);
                }
            }
            PenStrokes.Clear();
        }
            
    }
}
