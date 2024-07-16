using Fusion.Addons.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorMngr : MonoBehaviour
{

    public List<Color> colors = new List<Color>();
    public Drawer drawer;
    int currentColorIndex = 0;
    public Image colorImage;

    private void Start()
    {
        if (colors.Count != 0)
        {
            drawer.color = colors[currentColorIndex];
            colorImage.color = colors[currentColorIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        //when c is pressed 
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentColorIndex++;
            if (currentColorIndex >= colors.Count)
                currentColorIndex = 0;
            drawer.color = colors[currentColorIndex];
            colorImage.color = colors[currentColorIndex];
        }
    }
}
