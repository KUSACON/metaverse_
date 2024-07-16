using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Change_list_ : MonoBehaviour
{
    public GameObject roomList;
    public GameObject PatientList;

    public void ChangeList(bool isRoomList)
    {
        if (!isRoomList)
        {
            roomList.SetActive(false);
            PatientList.SetActive(true);
        }
        else
        {
            roomList.SetActive(true);
            PatientList.SetActive(false);
        }
    }

}
