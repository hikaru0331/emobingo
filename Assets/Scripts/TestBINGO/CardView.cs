using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image cardImage;
    [SerializeField] private TextMeshProUGUI cardNumberText;

    public void SetCardNumber(int cardNumber)
    {
        cardNumberText.text = cardNumber.ToString();
    }

    public void SetColor(Color imageColor , Color textColor)
    {
        cardImage.color = imageColor;
        cardNumberText.color = textColor;
    }
}