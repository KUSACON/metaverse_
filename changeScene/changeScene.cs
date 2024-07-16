using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public string lvlName = "Reception";
    public void letsChangeScene()
    {
        //change unit scnene to lvlName
        SceneManager.LoadScene(lvlName);
    }
}
