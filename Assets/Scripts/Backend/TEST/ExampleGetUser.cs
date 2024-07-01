using UnityEngine;

public class ExampleGetUser : MonoBehaviour
{
    private UserManager userManager;

    void Start()
    {
        // UserManagerゲームオブジェクトを見つけてUserManagerコンポーネントを取得
        userManager = GameObject.Find("UserManager").GetComponent<UserManager>();

        // ユーザー情報の取得をリクエスト
        userManager.GetUser("1");
    }
}