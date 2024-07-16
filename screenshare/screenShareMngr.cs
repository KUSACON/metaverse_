using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class screenShareMngr : MonoBehaviour
{

    public Button myButton;
    public List<GameObject> SS_list = new List<GameObject>();

    public bool DoToggle = true;

    private void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(ButtonClicked);
        }
    }

    void ButtonClicked()
    {
        if (!DoToggle)
            return;
        Debug.Log("Button was clicked to show screenshatr!");

        //toggle list of gameobjects
        foreach (GameObject go in SS_list)
        {
            go.SetActive(!go.activeSelf);
        }
    }
    
}
