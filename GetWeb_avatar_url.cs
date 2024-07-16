using ReadyPlayerMe.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeb_avatar_url : MonoBehaviour
{
    string avatarUrl = "https://models.readyplayer.me/64a5adf7e049fd58c890b22f.glb";

    //WebGLAvatarLoader webGLAvatarLoader;

    private void Start()
    {
        //webGLAvatarLoader = GetComponent<WebGLAvatarLoader>();
    }

    private void Update()
    {
        //avatarUrl = webGLAvatarLoader.avatarUrl;
        static_val.avatarUrl = avatarUrl;
    }

    public void _showURL()
    {
        Debug.Log(avatarUrl);
    }


}
