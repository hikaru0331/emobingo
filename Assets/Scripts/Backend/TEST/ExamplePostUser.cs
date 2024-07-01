// Assets/Scripts/Example/ExampleUserCreation.cs

using UnityEngine;

public class ExamplePostUser : MonoBehaviour
{
    private UserManager userManager;

    void Start()
    {
        // UserManagerゲームオブジェクトを見つけてUserManagerコンポーネントを取得
        userManager = GameObject.Find("UserManager").GetComponent<UserManager>();

        // ユーザーのデータを作成
        User newUser = new User
        {
            id = "1",
            name = "ユーザー名",
            room_id = "123",
            images = new Image[]
            {
                new Image
                {
                    url = "https://example.com/image.jpg",
                    emotion = "egao"
                }
            }
        };

        // ユーザー情報の作成をリクエスト
        userManager.CreateUser(newUser);
    }
}
