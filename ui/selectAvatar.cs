using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectAvatar : MonoBehaviour
{
    public string Avatar_url = "https://models.readyplayer.me/643fd148ff5f53cf9e1bed5e.glb";

    public string lvlName = "Recption";
    public short charType = 1;


    public void onClick_selectAvatar()
    {
        //static_val._characterType = charType;
        static_val.avatarUrl = Avatar_url;
        SceneManager.LoadScene(lvlName);
    }

    
}
