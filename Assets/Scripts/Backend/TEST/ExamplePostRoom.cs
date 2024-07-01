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
        Room newRoom = new Room
        {
            id = "1",
            users = new User[]
            {
                new User
                {
                    id = "1",
                    name = "ユーザー名",
                    room_id = "123"
                }
            },
            images = new RoomImage[]
            {
                new RoomImage
                {
                    image_id = "1",
                    user_id = "1",
                    url = "https://example.com/image.jpg"
                }
            }
        };

        // ルーム情報の作成をリクエスト
        roomManager.CreateRoom(newRoom);
    }
}
