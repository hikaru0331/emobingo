using UnityEngine;
public class ExampleDeleteUser : MonoBehaviour
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
        userManager = GameObject.Find("UserManager").GetComponent<UserManager>();

        // 削除するユーザーのIDを指定
        userManager.DeleteUser("3");
    }
}