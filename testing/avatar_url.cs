using ReadyPlayerMe.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avatar_url : MonoBehaviour
{

    TMPro.TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMPro.TMP_InputField>();  
    }

    // Update is called once per frame
    void Update()
    {
        //WebGLAvatarLoader.avatarUrl_static = inputField.text;
    }


}
