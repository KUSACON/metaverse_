//get_patientData

using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

[System.Serializable]
public class UserDetailsResponse
{
    public UserDetail details;
    public Doc[] docs;
}

[System.Serializable]
public class UserDetail
{
    public string name;
    public int age;
    public int Height;
    public string BG;
    public string BP;
}

[System.Serializable]
public class Doc
{
    public string name;
    public string url;
}

public class get_patientData : MonoBehaviour
{
    public UserDetailsResponse u_details;
    public TMPro.TMP_InputField userName;

    public TMPro.TMP_InputField name;
    public TMPro.TMP_InputField age;
    public TMPro.TMP_InputField height;
    public TMPro.TMP_InputField bloodGroup;
    public TMPro.TMP_InputField bloodPressure;

    // This method will be called to start the API request.
    public void FetchUserDetails()
    {
        string url = $"https://api.convrse.ai/b/hcl-healthcare/patient/details?user_id={userName.text}";
        StartCoroutine(GetRequest(url));
    }

    public void Fetch_Only_PatDetails()
    {
        string url = $"https://api.convrse.ai/b/hcl-healthcare/patient/details?user_id={stativ.userID}";
        StartCoroutine(GetRequest(url));
    }

    // Coroutine to send the GET request using UnityWebRequest
    private IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            // Send the request and wait for a response
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + request.error);
            }
            else
            {
                // Process the response
                string jsonResponse = request.downloadHandler.text;
                UserDetailsResponse userDetails = JsonUtility.FromJson<UserDetailsResponse>(jsonResponse);
                SaveUserDetails(userDetails);
                Debug.Log("User details fetched successfully.");
            }
        }
    }

    // This method saves the details, you can implement it to do whatever you need with the data
    private void SaveUserDetails(UserDetailsResponse details)
    {
        u_details = details;
        name.text = details.details.name;
        age.text = details.details.age.ToString();
        height.text = details.details.Height.ToString();
        bloodGroup.text = details.details.BG;
        bloodPressure.text = details.details.BP;

        // Save or process the details as needed
        Debug.Log("User Name: " + details.details.name);
        Debug.Log("User Age: " + details.details.age);
        Debug.Log("User Height: " + details.details.Height);
        Debug.Log("User Blood Group: " + details.details.BG);
        Debug.Log("User Blood Pressure: " + details.details.BP);

        // If there are documents, process them
        if (details.docs != null)
        {
            foreach (var doc in details.docs)
            {
                Debug.Log("Document Name: " + doc.name);
                Debug.Log("Document URL: " + doc.url);
            }
        }

        GetComponent<files_mngr>().ManageList();
    }
}
