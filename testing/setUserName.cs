using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setUserName : MonoBehaviour
{
    public string userName = "k1";

    [Tooltip("0 is doc. 1 is nurse. 2 is patient")]
    public short characterType = 1;


    private void Awake()
    {
        Debug.Log("setUserName Awake");
        static_val._AvatarName = userName;
        static_val._characterType = characterType;
        static_val.avatarUrl = "https://models.readyplayer.me/650401de682fb1a37110d843.glb";
        //Debug.Log("static_val.userName = " + static_val.userName);
    }
}
