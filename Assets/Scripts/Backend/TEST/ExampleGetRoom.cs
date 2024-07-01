using UnityEngine;

public class ExampleGetRoom : MonoBehaviour
{
    private RoomManager roomManager;

    void Start()
    {
        // RoomManagerゲームオブジェクトを見つけてRoomManagerコンポーネントを取得
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();

        // ルーム情報の取得をリクエスト
        roomManager.GetRoom("1");
    }
}
