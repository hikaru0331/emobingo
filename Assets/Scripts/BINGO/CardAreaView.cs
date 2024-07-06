using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class CardAreaView : MonoBehaviour
{
    [SerializeField] private Color closeImageColor;
    [SerializeField] private Color closeTextColor;
    [SerializeField] private Color openImageColor;
    [SerializeField] private Color openTextColor;

    [SerializeField] private CardView[] cardViews;

    public void SetCardNumber(int cardIndex, int cardNumber)
    {
        cardViews[cardIndex].SetCardNumber(cardNumber);
    }

    public void SetCardImage(int cardIndex, int cardNumber, Room currentRoom)
    {
        //cardNumberがroomのimage_id
        // image_id が 1 のときの url を取得する
        Texture2D texture = Resources.Load<Texture2D>("test_backend/cry");
        cardViews[cardIndex].ChangeImage(texture);

        // foreach (var image in currentRoom.images)
        // {
        //     if (int.Parse(image.image_id) == cardNumber)
        //     {
        //         url = image.url;
        //         Debug.Log("url: " + url);

        //         // コルーチンで非同期にリクエストを処理
        //         StartCoroutine(DownloadImage(url, cardIndex));
        //         break;
        //     }
        // }
    }

    // private IEnumerator DownloadImage(string url, int cardIndex)
    // {
    //     UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
    //     yield return www.SendWebRequest();

    //     if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
    //     {
    //         Debug.LogError(www.error);
    //     }
    //     else
    //     {
    //         Texture2D texture = DownloadHandlerTexture.GetContent(www);
    //         cardViews[cardIndex].ChangeImage(texture);
    //     }
    // }

    public void SetCardOpen(int cardIndex)
    {
        cardViews[cardIndex].SetColor(openImageColor, openTextColor);
    }

    public void SetCardClose(int cardIndex)
    {
        cardViews[cardIndex].SetColor(closeImageColor, closeTextColor);
    }
}