using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide4patient : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (static_val._characterType == 2)
        {
            this.gameObject.SetActive(false);
        }        
    }

}
