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
}
