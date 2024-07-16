using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using static add_pat_data;

public class add_pat_data : MonoBehaviour
{
    [System.Serializable]
    public class UserDetails
    {
        public string user_id;
        public UserDetail details;
    }

    [System.Serializable]
    public class UserDetail
    {
        public string name;
        public string age;
        public string Height;
        public string BG;
        public string BP;
    }

    public TMPro.TMP_InputField inp_name;
    public TMPro.TMP_InputField inp_age;
    public TMPro.TMP_InputField inp_height;
    public TMPro.TMP_InputField inp_bg;
    public TMPro.TMP_InputField inp_bp;


    // Call this method to send the details to the API
    public void SendUserDetails()
    {
        UserDetails userDetails = new UserDetails
        {
            user_id = inp_name.text,
            details = new UserDetail
            {
                name = inp_name.text,
                age = inp_age.text,
                Height = inp_height.text,
                BG = inp_bg.text,
                BP = inp_bp.text
            }
        };
        string json = JsonUtility.ToJson(userDetails);
        StartCoroutine(PostRequest("https://api.convrse.ai/b/hcl-healthcare/patient/details", json));
    }

    private IEnumerator PostRequest(string url, string json)
    {
        // Create a new UnityWebRequest object with the specified URL and method (POST)
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // Send the request and wait until it's finished
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }


}
