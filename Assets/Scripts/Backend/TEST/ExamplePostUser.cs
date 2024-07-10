// Assets/Scripts/Example/ExampleUserCreation.cs

using UnityEngine;
using System;

public class ExamplePostUser : MonoBehaviour
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
        // 黒魔術　意味わからん　https://qiita.com/Katumadeyaruhiko/items/c2b9b4ccdfe51df4ad4a
        Texture2D createReadabeTexture2D(Texture2D texture2d)
            {
                RenderTexture renderTexture = RenderTexture.GetTemporary(
                    texture2d.width,
                    texture2d.height,
                    0,
                    RenderTextureFormat.Default,
                    RenderTextureReadWrite.Default);

                Graphics.Blit(texture2d, renderTexture);
                RenderTexture previous = RenderTexture.active;
                RenderTexture.active = renderTexture;
                Texture2D readableTextur2D = new Texture2D(texture2d.width, texture2d.height);
                readableTextur2D.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
                readableTextur2D.Apply();
                RenderTexture.active = previous;
                RenderTexture.ReleaseTemporary(renderTexture);
                return readableTextur2D;
            }
        // イメージ(Resources) → byte配列
        byte[] ImageToBytes(string name) {
            Texture2D text_asset = Resources.Load<Texture2D>(name);
            ;
            return createReadabeTexture2D(text_asset).EncodeToPNG();
        }

        // イメージ(Resources) → Base64
        string ImageToBase64(string path) {
            byte[] byteArray = ImageToBytes(path);
            return Convert.ToBase64String (byteArray);
        }

        // Convert the image bytes to base64 string
        string imageBase64_smile =ImageToBase64("test_backend/smile");
        string imageBase64_cry = ImageToBase64("test_backend/cry");
        // ユーザーのデータを作成
        User newUser = new User
        {
            id = "33333",
            name = "Unity太郎",
            room_id = "1111",

            images = new ImageDTO[]

            {
                new ImageDTO
                {
                    image_base64 = imageBase64_smile,
                    emotion = "egao"
                },
                new ImageDTO
                {
                    image_base64 = imageBase64_cry,
                    emotion = "cry"
                }
            }
        };

        // ユーザー情報の作成をリクエスト
        userManager.CreateUser(newUser);
    }
}
