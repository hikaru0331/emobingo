// Assets/Scripts/Models/User.cs

[System.Serializable]
public class User
{
    public string id;
    public string name;
    public string room_id;
    public Image[] images;
}

[System.Serializable]
public class Image
{
    public string image_base64;
    public string emotion;
}
