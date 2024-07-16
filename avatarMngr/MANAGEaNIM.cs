using Fusion.XR.Shared.Desktop;
using ReadyPlayerMe.Core.WebView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MANAGEaNIM : MonoBehaviour
{
    playerOrientation playerOrientation;
    public DesktopController desktopController;


    // Start is called before the first frame update
    void Start()
    {
        playerOrientation = GetComponent<playerOrientation>();
        desktopController = FindObjectOfType<DesktopController>();


    }

    // Update is called once per frame
    void Update()
    {
        if (playerOrientation.HasInputAuthority)
        {
            if (!desktopController)
            {
                desktopController = FindObjectOfType<DesktopController>();
                return;
            }
            float inp = desktopController.forwardAction.action.ReadValue<Vector2>().y;
            if (playerOrientation.newAv)
            {
                Animator anim = playerOrientation.newAv.GetComponent<Animator>();
                if (anim)
                {
                    anim.SetFloat("MoveSpeed", inp*4);    
                }

            }
            else
            {
                Animator anim = playerOrientation.DefaultAvatar.GetComponent<Animator>();
                if (anim)
                {
                    anim.SetFloat("MoveSpeed", inp * 4);
                }
            }
        }
    }
}
