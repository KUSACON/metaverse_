using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class policy_1 : MonoBehaviour
{
    [System.Serializable]
    public class ResponseClass
    {
        public string policy;
        public string x_amz_algorithm;
        public string x_amz_credential;
        public string x_amz_date;
        public string x_amz_signature;
        public string expiration;
        public string bucket;
        public string key;
        public string contentId;
        public string filePath;
    }

    public ResponseClass response = new ResponseClass();

    string featureName = "HCL_HEALTHCARE_DOC_UPLOAD";

    string jwtToken = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1aWQiOiJwZ0xNek53YWJrLTAiLCJpYXQiOjE2NzAyNDU0MzZ9.kMJJr9ccKrk2HbaaFBw00QY_CdZgbz2qJJsHDDSBXdAcLXqQa7LggBjStFJnr6pE1VQFowvtwqSIZV6V5R7X2Q544eHEmaYfOMG5LwL8UFD_KNGuBOmeiVZ0YTiey1qvt1MHJVx5dCuvLDQxbsUKSHUhm-OX_Oav60xl5YkU9-mvRMS1nRxeQXl9MbnnQEIuQWOYh-xgx1-tv1KFImTD1oLmrdbhpmJDkwW8BULR0LLgyrl4_cIIUOHB0OXW7gPdIdhU9h1ki6KwKVTNdepSW6fzN6j1LJ2FeU0I1qxu7KGmz1-Yril6cjO1MnorE_nZrMDN0Sh2YBBHHu5qTAvMng"; // Replace with your actual JWT

    string fileName = "";
 
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        Debug.Log("jwtToken : " + stativ.api_token);
        Debug.Log(stativ.userID);
        Debug.Log("22222222222222222222222222222222222222222222");

        //jwtToken = stativ.api_token;
        //UploadFile("convrse-icon.png", "HCL_HEALTHCARE_DOC_UPLOAD");
    }




    public void UploadFile()
    {
        featureName = "HCL_HEALTHCARE_DOC_UPLOAD";
        Debug.Log("==>" + System.IO.Path.GetFileName(stativ.filePath[0]));
        fileName = System.IO.Path.GetFileName(stativ.filePath[0]);
        StartCoroutine(UploadFileCoroutine(System.IO.Path.GetFileName(stativ.filePath[0]), featureName));
    }


    private IEnumerator UploadFileCoroutine(string fileName, string featureName)
    {
        string url = "https://api.convrse.ai/b/filemanager/upload-policy";

        // Create JSON data from the method parameters
        string bodyJson = $"{{\"fileName\":\"{fileName}\", \"featureName\":\"{featureName}\"}}";

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJson);

        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        request.SetRequestHeader("convrsejwt", jwtToken); // Set the JWT in the request header


        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);

            Debug.LogError("Received error response: " + request.downloadHandler.text);
        }
        else
        {

            //response = JsonUtility.FromJson<ResponseClass>(request.downloadHandler.text);

            Debug.Log(request.downloadHandler.text);

            string json = request.downloadHandler.text;
            json = json.Replace("\"x-amz-algorithm\":", "\"x_amz_algorithm\":")
                       .Replace("\"x-amz-credential\":", "\"x_amz_credential\":")
                       .Replace("\"x-amz-date\":", "\"x_amz_date\":")
                       .Replace("\"x-amz-signature\":", "\"x_amz_signature\":");

            response = JsonUtility.FromJson<ResponseClass>(json);

            Debug.Log("repoonse policy : " + response.policy);
            Debug.Log("repoonse x_amz_algorithm : " + response.x_amz_algorithm);
            Debug.Log("repoonse x_amz_credential : " + response.x_amz_credential);
            Debug.Log("repoonse x_amz_date : " + response.x_amz_date);
            Debug.Log("repoonse x_amz_signature : " + response.x_amz_signature);
            Debug.Log("repoonse expiration : " + response.expiration);
            Debug.Log("repoonse bucket : " + response.bucket);

            Debug.Log("repoonse key : " + response.key);
            Debug.Log("repoonse contentId : " + response.contentId);
            Debug.Log("repoonse filePath : " + response.filePath);
            ////////////////////////////////////////////////////////////////////////
            StartCoroutine(UploadToS3());
        }
    }

    private IEnumerator UploadToS3()
    {
        string url = "https://hcl-healthcare.s3.amazonaws.com/"; // The URL to your S3 bucket

        WWWForm form = new WWWForm();
        form.AddField("key", response.key);
        form.AddField("policy", response.policy);
        form.AddField("X-Amz-Algorithm", response.x_amz_algorithm);
        form.AddField("X-Amz-Credential", response.x_amz_credential);
        form.AddField("X-Amz-Date", response.x_amz_date);
        form.AddField("X-Amz-Signature", response.x_amz_signature);
        form.AddField("x-amz-meta-contentid", response.contentId); // Assuming you have this in your response

        // Add the file. The "file" field name should match with your API expectation.
        // Make sure that the file at filePath is readable and the path is correct.
        byte[] fileData = stativ.file.bytes;//System.IO.File.ReadAllBytes(filePath);
        Debug.Log("fileData : " + fileData);
        Debug.Log("fileData size: " + stativ.file);
        Debug.Log("name: " + System.IO.Path.GetFileName(stativ.filePath[0]));
        form.AddBinaryData("file", fileData, System.IO.Path.GetFileName(stativ.filePath[0]));

        UnityWebRequest uploadRequest = UnityWebRequest.Post(url, form);
        yield return uploadRequest.SendWebRequest();

        if (uploadRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error uploading to S3: " + uploadRequest.error);
            Debug.LogError("Received error response: " + uploadRequest.downloadHandler.text);
        }
        else
        {
            //enter code response after api call 
            Debug.Log(uploadRequest.responseCode);

            Debug.Log("Success uploading to S3");
            // Additional success handling as needed
            StartCoroutine(CallNextAPI());

        }
    }

    [System.Serializable]
    public class RequestBodyData
    {
        public string filePath;
        public string contentId;
        public string featureName;
    }

    private IEnumerator CallNextAPI()
    {
        string url = "https://api.convrse.ai/b/filemanager/content";

        // Prepare the request body as a JSON string
        /*string bodyJsonString = JsonUtility.ToJson(new
        {
            filePath = response.key,
            contentId = response.contentId,
            featureName = this.featureName
        });
*/


        RequestBodyData rbd = new RequestBodyData();
        rbd.filePath = response.key;
        rbd.contentId = response.contentId;
        rbd.featureName = this.featureName;

        Debug.Log("requestBodystr : " + rbd.filePath);
        Debug.Log("requestBodystr : " + rbd.contentId);
        Debug.Log("requestBodystr : " + rbd.featureName);

        // Serialize the request body to a JSON string
        string bodyJsonString = JsonUtility.ToJson(rbd);
        Debug.Log("ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss");
        Debug.Log(bodyJsonString);

        // Convert JSON string to byte array
        byte[] requestBody = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);

        // Create a new UnityWebRequest, set method to POST and attach the body data
        using (UnityWebRequest nextApiRequest = new UnityWebRequest(url, "POST"))
        {
            nextApiRequest.uploadHandler = new UploadHandlerRaw(requestBody);
            nextApiRequest.downloadHandler = new DownloadHandlerBuffer();

            // Set the content type header to application/json; charset=utf-8
            nextApiRequest.SetRequestHeader("Content-Type", "application/json; charset=utf-8");
            nextApiRequest.SetRequestHeader("convrsejwt", jwtToken); // Set the JWT in the request header


            // You may need to add additional headers such as Authorization depending on the API requirements
            //nextApiRequest.SetRequestHeader("convrsejwt", "Bearer " + jwtToken);

            // Send the request and wait for a response
            yield return nextApiRequest.SendWebRequest();

            if (nextApiRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error calling the next API: " + nextApiRequest.error);

                Debug.LogError("Received error response: " + nextApiRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("Next API call was successful: " + nextApiRequest.downloadHandler.text);
                StartCoroutine(AddDocApi());
                // Parse the response if needed
                // var response = JsonUtility.FromJson<ResponseType>(nextApiRequest.downloadHandler.text);
            }
        }
    }

    [System.Serializable]
    public class ApiRequestBody_Add_doc
    {
        public string content_id;
        public string user_id;
        public string file_name;
    }

    private IEnumerator AddDocApi()
    {
        string url = "https://api.convrse.ai/b/hcl-healthcare/user-docs";

        // Create the request body object
        ApiRequestBody_Add_doc requestBody = new ApiRequestBody_Add_doc()
        {
            content_id = response.contentId,
            user_id = stativ.userID,
            file_name = fileName
        };

        // Serialize the request body to a JSON string
        string bodyJsonString = JsonUtility.ToJson(requestBody);
        byte[] requestBodyData = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);

        // Create the UnityWebRequest object for sending the request
        using (UnityWebRequest apiRequest = new UnityWebRequest(url, "POST"))
        {
            apiRequest.uploadHandler = new UploadHandlerRaw(requestBodyData);
            apiRequest.downloadHandler = new DownloadHandlerBuffer();

            // Set the content type header to application/json
            apiRequest.SetRequestHeader("Content-Type", "application/json");

            // Add the JWT token if required for authorization
            // apiRequest.SetRequestHeader("Authorization", "Bearer " + jwtToken);
            apiRequest.SetRequestHeader("convrsejwt", jwtToken); 
           // Send the request and wait for the response
           yield return apiRequest.SendWebRequest();

            if (apiRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + apiRequest.error);
                Debug.LogError("Response: " + apiRequest.downloadHandler.text);
            }
            else
            {
                Debug.Log("Response: " + apiRequest.downloadHandler.text);
                // Handle the response as needed
            }
        }
    }





}
