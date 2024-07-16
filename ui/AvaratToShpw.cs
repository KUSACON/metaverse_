using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaratToShpw : MonoBehaviour
{
    [SerializeField]
    List<GameObject> avatars = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject g in avatars)
        {
            //disable all avatars
            g.SetActive(false);
        }

        //0 is doc. 1 is nurse. 2 is patient
        if (static_val._characterType == 0)
        {
            avatars[0].SetActive(true);
        }
        else if (static_val._characterType == 1)
        {
            avatars[1].SetActive(true);
        }
        else if (static_val._characterType == 2)
        {
            avatars[2].SetActive(true);
        }

    }

}
