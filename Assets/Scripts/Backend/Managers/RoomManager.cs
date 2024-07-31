
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private APIClient apiClient;

    private void Start()
    {
        apiClient = gameObject.AddComponent<APIClient>();
    }

    public void CreateRoom(PostRoom room)
    {
        string url = "https://die-webapi.azurewebsites.net/api/rooms/";
        string json = JsonUtility.ToJson(room);

        StartCoroutine(apiClient.PostRequest(url, json, (response) => {
            Debug.Log("Room created: " + response);
        }));
    }

    public void GetRoom(string roomId)
    {
        string url = $"https://die-webapi.azurewebsites.net/api/rooms/{roomId}";

        StartCoroutine(apiClient.GetRequest(url, (response) => {
            RoomDTO room = JsonUtility.FromJson<RoomDTO>(response);
        }));
    }
}
