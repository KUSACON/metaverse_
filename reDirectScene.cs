using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reDirectScene : MonoBehaviour
{
    public string VR_sceneName;
    public string non_VR_sceneName;


    // Start is called before the first frame update
    void Start()
    {
        if (static_val.isInVR)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(VR_sceneName);
        }else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(non_VR_sceneName);
        }

    }

}
