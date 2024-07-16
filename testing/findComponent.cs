using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findComponent : MonoBehaviour
{
    public AudioListener[] listeners;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndPrint(5.0f));
         
    }

    // create coroutine
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        Debug.Log("========================================================================");
        // Find all AudioListener components in the current scene
        listeners = FindObjectsOfType<AudioListener>();

        // Print out the name of each GameObject that has an AudioListener attached
        foreach (AudioListener listener in listeners)
        {
            Debug.Log("Found AudioListener on GameObject: " + listener.gameObject.name);
        }
    }

    
}
