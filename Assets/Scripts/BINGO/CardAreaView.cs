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

    public void SetCardImage(int cardIndex, int cardNumber, RoomDTO currentRoom)
    {
        //cardNumberがroomのimage_id
        // image_id が 1 のときの url を取得する
        // Texture2D texture1 = Resources.Load<Texture2D>("test_backend/cry");
        // cardViews[0].ChangeImage(texture1);
        // Texture2D texture2 = Resources.Load<Texture2D>("test_backend/angry");
        // cardViews[1].ChangeImage(texture2);
        // Texture2D texture3 = Resources.Load<Texture2D>("test_backend/smile");
        // cardViews[2].ChangeImage(texture3);
        // Texture2D texture4 = Resources.Load<Texture2D>("test_backend/gal_o_man");
        // cardViews[3].ChangeImage(texture4);
        // Texture2D texture5 = Resources.Load<Texture2D>("test_backend/hengao_mabuta_uragaesu");
        // cardViews[4].ChangeImage(texture5);
        // Texture2D texture6 = Resources.Load<Texture2D>("test_backend/kesyou_jirai_make");
        // cardViews[5].ChangeImage(texture6);
        // Texture2D texture7 = Resources.Load<Texture2D>("test_backend/penlight_man02_red");
        // cardViews[6].ChangeImage(texture7);
        // Texture2D texture8 = Resources.Load<Texture2D>("test_backend/pose_reiwa_man");
        // cardViews[7].ChangeImage(texture8);
        // Texture2D texture9 = Resources.Load<Texture2D>("test_backend/osyaberi_man");
        // cardViews[8].ChangeImage(texture9);

        foreach (var image in currentRoom.images)
        {
            if (int.Parse(image.image_id) == cardNumber)
            {
                string url = image.url;
                Debug.Log("url: " + url);

                // コルーチンで非同期にリクエストを処理
                StartCoroutine(DownloadImage(url, cardIndex));
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