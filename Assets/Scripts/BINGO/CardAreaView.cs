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

    public void SetCardEmotion(int cardIndex, string cardEmotion)
    {
        cardViews[cardIndex].SetCardEmotion(cardEmotion);
    }

    public void SetCardName(int cardIndex, string cardName)
    {
        cardViews[cardIndex].SetCardName(cardName);
    }

    public void SetCardImage(int cardIndex, int cardNumber, RoomDTO currentRoom)
    {
        foreach (var image in currentRoom.images)
        {
            if (int.Parse(image.image_id) == cardNumber)
            {
                
                Debug.Log("url: " + image.url);

                // コルーチンで非同期にリクエストを処理
                StartCoroutine(DownloadImage(image.url, cardIndex));
                break;
            }
        }
    }

    private IEnumerator DownloadImage(string url, int cardIndex)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            cardViews[cardIndex].ChangeImage(texture);
        }
    }

    public void SetCardOpen(int cardIndex)
    {
        cardViews[cardIndex].SetColor(openImageColor, openTextColor);
    }

    public void SetCardClose(int cardIndex)
    {
        cardViews[cardIndex].SetColor(closeImageColor, closeTextColor);
    }
}