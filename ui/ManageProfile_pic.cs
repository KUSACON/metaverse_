using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageProfile_pic : MonoBehaviour
{
    public profilePhoto _profilePhoto;
    public List<Image> sprite2Change;

    private void Start()
    {
        if (!_profilePhoto)
            _profilePhoto = GetComponent<profilePhoto>();
        int idx = -1;
        //foreach (string s in profilePhoto.names)
        for (int i =0; i< _profilePhoto.names.Count; i++)
        {
            Debug.Log("profilePhoto.name[i]: " + _profilePhoto.names[i]);
            Debug.Log("static_val.avatarUrl: " + static_val.avatarUrl);
            if (_profilePhoto.names[i].Equals(static_val.avatarUrl))
            {
                idx = i;
                Debug.Log("found idx: " + idx);
            }
        }
        if (idx != -1)
        {
            foreach (Image s in sprite2Change)
            {
                s.sprite = _profilePhoto.sprites[idx];
            }
        }


    }
}
