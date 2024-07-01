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
        string url = "https://api.example.com/users";
        string json = JsonUtility.ToJson(user);

        StartCoroutine(apiClient.PostRequest(url, json, (response) => {
            Debug.Log("User created: " + response);
        }));
    }

    public void GetUser(string userId)
    {
        string url = $"https://api.example.com/users/{userId}";

        StartCoroutine(apiClient.GetRequest(url, (response) => {
            User user = JsonUtility.FromJson<User>(response);
            Debug.Log("User data: " + user.name);
        }));
    }
}
