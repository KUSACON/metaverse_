using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toggleList_data : MonoBehaviour
{
    public GameObject info;
    public GameObject files;

    public GameObject info_btn;
    public GameObject files_btn;

    private void Start()
    {
        info.SetActive(true);
        files.SetActive(false);
        info_btn.SetActive(false);
    }

    public void showFiles()
    {
        info.SetActive(false);
        files.SetActive(true);
        info_btn.SetActive(true);
        files_btn.SetActive(false);

    }

    public void showInfo()
    {
        info.SetActive(true);
        files.SetActive(false);
        info_btn.SetActive(false);
        files_btn.SetActive(true);
    }

}
