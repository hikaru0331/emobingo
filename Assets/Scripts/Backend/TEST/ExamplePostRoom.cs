// Assets/Scripts/Example/ExampleRoomCreation.cs

using UnityEngine;

public class ExamplePostRoom : MonoBehaviour
{
    private RoomManager roomManager;

    void Start()
    {

    }
    void Update()
    {

    }
    
    public void OnClickEvent()
    {
        // RoomManagerゲームオブジェクトを見つけてRoomManagerコンポーネントを取得
        roomManager = GameObject.Find("RoomManager").GetComponent<RoomManager>();

        // ルームのデータを作成
        PostRoom newRoom = new PostRoom
        {
            room_id = "2222"
        };

        // ルーム情報の作成をリクエスト
        roomManager.CreateRoom(newRoom);
    }
}
