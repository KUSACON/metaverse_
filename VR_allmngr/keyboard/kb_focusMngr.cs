using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kb_focusMngr : MonoBehaviour
{

    public TMPro.TMP_InputField KeyBoard_output;
    public TMPro.TMP_InputField userName;
    public TMPro.TMP_InputField password;

    int _focus = 0;

    public void setFocus(int focus)
    {
        _focus = focus;
    }

    public void clear()
    {
        
        KeyBoard_output.text = "";
        /*
        if (_focus == 0)
        {
            //KeyBoard_output.text = userName.text;
            userName.text = "";
        }
        else if (_focus == 1)
        {
            //KeyBoard_output.text = password.text;
            password.text = "";
        }
        */
    }

    public void Update_text()
    {
        if (_focus == 0)
        {
            userName.text = KeyBoard_output.text;
        }else if (_focus == 1)
        {
            password.text = KeyBoard_output.text;
        }
    }


}
