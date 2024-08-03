// Assets/Scripts/Managers/UserManager.cs

using UnityEngine;

public class UserManager : MonoBehaviour
{
    private APIClient apiClient = new APIClient();

    public void CreateUser(User user)
    {
        string url = "https://die-webapi.azurewebsites.net/api/users/";
        string json = JsonUtility.ToJson(user);

        StartCoroutine(apiClient.PostRequest(url, json, (response) => {
            Debug.Log("User created: " + response);
        }));
    }

    public void GetUser(string userId)
    {
        string url = $"https://die-webapi.azurewebsites.net/api/users/{userId}";

        StartCoroutine(apiClient.GetRequest(url, (response) => {
            User user = JsonUtility.FromJson<User>(response);
            Debug.Log("User id: " + user.id);
            Debug.Log("User name: " + user.name);
            Debug.Log("User images: " + user.images);
            Debug.Log("User room_id: " + user.room_id);
        }));
    }

    public void DeleteUser(string userId)
    {
        string url = $"https://die-webapi.azurewebsites.net/api/users/{userId}";

        StartCoroutine(apiClient.DeleteRequest(url, (response) => {
            Debug.Log("User deleted: " + response);
        }));
    }
}
