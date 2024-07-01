// Assets/Scripts/Managers/UserManager.cs

using UnityEngine;

public class UserManager : MonoBehaviour
{
    private APIClient apiClient;

    private void Start()
    {
        apiClient = gameObject.AddComponent<APIClient>();
    }

    public void CreateUser(User user)
    {
        string url = "http://localhost:7071/api/users";
        string json = JsonUtility.ToJson(user);

        StartCoroutine(apiClient.PostRequest(url, json, (response) => {
            Debug.Log("User created: " + response);
        }));
    }

    public void GetUser(string userId)
    {
        string url = $"http://localhost:7071/api/users/{userId}";

        StartCoroutine(apiClient.GetRequest(url, (response) => {
            User user = JsonUtility.FromJson<User>(response);
            Debug.Log("User id: " + user.id);
            Debug.Log("User name: " + user.name);
            Debug.Log("User images: " + user.images);
            Debug.Log("User room_id: " + user.room_id);
        }));
    }
}
