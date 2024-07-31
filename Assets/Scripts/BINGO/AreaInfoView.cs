using UnityEngine;
using TMPro;

public class AreaInfoView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentEmotionText;
    [SerializeField] private TextMeshProUGUI currentNameText;
    [SerializeField] private UnityEngine.UI.Image currentImage;
    [SerializeField] private TextMeshProUGUI subInfoText;
    public TextMeshProUGUI CurrentEmotionText => currentEmotionText;
    public TextMeshProUGUI CurrentNameText => currentNameText;
    public UnityEngine.UI.Image CurrentImage => currentImage;
    public TextMeshProUGUI SubInfoText => subInfoText;

    //ここでこの数字のImageも入れるコード追加したい
    private void Start()
    {
        BingoManager.OnBingoNumber += (number,sprite) =>
        {
            currentImage.sprite = sprite;
        };
        subInfoText.text = "";
        BingoManager.OnChangeSubInfoText += (text) =>
        {
            subInfoText.text = text;
        };
        currentNameText.text = "";
        BingoManager.OnChangeAreaName +=(name)=>
        {
            currentNameText.text = name;
        };
        currentEmotionText.text = "";
        BingoManager.OnBingoEmotion += (emotion) =>
        {
            currentEmotionText.text = emotion;
        };
    }
}
