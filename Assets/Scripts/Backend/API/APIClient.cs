// Assets/Scripts/API/APIClient.cs

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class APIClient : MonoBehaviour
{
    public IEnumerator PostRequest(string url, string json, System.Action<string> callback)
    {
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        using (UnityWebRequest webRequest = new UnityWebRequest(url, "POST"))
        {
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            
            string function_key = MyKey.function_key;
            webRequest.SetRequestHeader("x-functions-key",function_key);
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                callback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetRequest(string url, System.Action<string> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            string function_key = MyKey.function_key;
            webRequest.SetRequestHeader("x-functions-key",function_key);
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                callback?.Invoke(webRequest.downloadHandler.text);
            }
        }
    }

    public IEnumerator DeleteRequest(string url, System.Action<string> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Delete(url))
        {
            string function_key = MyKey.function_key;
            webRequest.SetRequestHeader("x-functions-key",function_key);
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                Debug.Log("Deleted:");
            }
        }
    }
}
