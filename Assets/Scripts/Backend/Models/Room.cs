// Assets/Scripts/Models/Room.cs

[System.Serializable]
public class RoomDTO
{
    public string id;
    public User[] users;
    public RoomImage[] images;
}

[System.Serializable]
public class RoomImage
{
    public string image_id;
    public string user_id;
    public string url;
}

[System.Serializable]
public class PostRoom
{
    public string room_id;
}