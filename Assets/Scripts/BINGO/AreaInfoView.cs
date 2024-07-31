using UnityEngine;
using TMPro;

public class AreaInfoView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentNumberText;
    [SerializeField] private TextMeshProUGUI currentNameText;
    [SerializeField] private UnityEngine.UI.Image currentImage;
    [SerializeField] private TextMeshProUGUI subInfoText;
    public TextMeshProUGUI CurrentNumberText => currentNumberText;
    public TextMeshProUGUI CurrentNameText => currentNameText;
    public UnityEngine.UI.Image CurrentImage => currentImage;
    public TextMeshProUGUI SubInfoText => subInfoText;

    //ここでこの数字のImageも入れるコード追加したい
    private void Start()
    {
        BingoManager.OnBingoNumber += (number,sprite) =>
        {
            currentNumberText.text = number.ToString();
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
    }
}
