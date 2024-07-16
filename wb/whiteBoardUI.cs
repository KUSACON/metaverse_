using Fusion.Addons.DesktopFocusAddon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class whiteBoardUI : MonoBehaviour
{
    public Button myButton;
    public DesktopFocus df;

    // Start is called before the first frame update
    private void Start()
    {
        if (myButton != null)
        {
            myButton.onClick.AddListener(ButtonClicked);
        }
    }

    void ButtonClicked()
    {
        Debug.Log("Button was clicked to show screenshatr!");
        df.ActivateFocus();
    }
}
