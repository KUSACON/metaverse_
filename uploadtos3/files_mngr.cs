using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class files_mngr : MonoBehaviour
{
    public GameObject ContentParent;

    public set_downloadData filePrefab; 
    public get_patientData g_patientData;


    public void ManageList()
    {


        Debug.Log("ManageList");
        clearAllChild();
        AddListItems();
    }

    void clearAllChild()
    {
        Debug.Log("clearAllChild");
        
        foreach (Transform child in ContentParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

    void AddListItems()
    {
        Debug.Log("AddListItems");

        foreach (var item in g_patientData.u_details.docs)
        { 

            set_downloadData go = Instantiate(filePrefab, ContentParent.transform);
            //set parent to this game object 
            go.transform.SetParent(ContentParent.transform);
            
            go.Setdata(item.name, item.url);
        }
    }


}
