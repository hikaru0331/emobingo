using UnityEngine;
using UnityEngine.UI;
using TMPro;

// マスごとのテキストや画像を管理するクラス
public class CardView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image cardImage;
    [SerializeField] private TextMeshProUGUI cardEmotionText;
    [SerializeField] private TextMeshProUGUI cardNameText;

    public void SetCardEmotion(string cardEmotion)
    {
        cardEmotionText.text = cardEmotion;
    }

    public void SetCardName(string cardName)
    {
        cardNameText.text = cardName;
    }

    public void ChangeImage(Texture2D texture)
    {
        cardImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }

    public void SetColor(Color imageColor , Color textColor)
    {
        cardImage.color = imageColor;
        cardEmotionText.color = textColor;
    }
}