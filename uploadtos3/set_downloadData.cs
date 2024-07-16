using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set_downloadData : MonoBehaviour
{
    public Button SendBtn;
    public TMPro.TMP_Text fileName;
    string url;

    public void Setdata(string name, string _url)
    {
        fileName.text = name;
        url = _url;
    }

    public void openUrl()
    {
        //open link in browser
        Application.OpenURL(url);

    }
}
