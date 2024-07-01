using UnityEngine;

public class ExampleGetUser : MonoBehaviour
{
    private UserManager userManager;

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnClickEvent()
    {
        // UserManagerゲームオブジェクトを見つけてUserManagerコンポーネントを取得
        GameObject userManagerObject = GameObject.Find("UserManager");

        if (userManagerObject != null)
        {
            userManager = userManagerObject.GetComponent<UserManager>();

            if (userManager != null)
            {
                // ユーザー情報の取得をリクエスト
                userManager.GetUser("d322e035-a21b-4533-ad4e-0eae373bccac");
            }
            else
            {
                Debug.LogError("UserManager component is missing on the UserManager object.");
            }
        }
        else
        {
            Debug.LogError("UserManager object not found in the scene.");
        }
    }
}
