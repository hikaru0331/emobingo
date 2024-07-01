
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private APIClient apiClient;

    private void Start()
    {
        apiClient = gameObject.AddComponent<APIClient>();
    }

    public void CreateRoom(Room room)
    {
        string url = "https://api.example.com/rooms";
        string json = JsonUtility.ToJson(room);

        StartCoroutine(apiClient.PostRequest(url, json, (response) => {
            Debug.Log("Room created: " + response);
        }));
    }

    public void GetRoom(string roomId)
    {
        string url = $"https://api.example.com/rooms/{roomId}";

        StartCoroutine(apiClient.GetRequest(url, (response) => {
            Room room = JsonUtility.FromJson<Room>(response);
            Debug.Log("Room data: " + room.id);
        }));
    }
}
