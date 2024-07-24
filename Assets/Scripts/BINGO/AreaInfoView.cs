using UnityEngine;
using TMPro;

public class AreaInfoView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentNumberText;
    [SerializeField] private UnityEngine.UI.Image currentImage;
    [SerializeField] private TextMeshProUGUI subInfoText;
    public TextMeshProUGUI CurrentNumberText => currentNumberText;
    public UnityEngine.UI.Image CurrentImage => currentImage;
    public TextMeshProUGUI SubInfoText => subInfoText;

    //ここでこの数字のImageも入れるコード追加したい
    private void Start()
    {
        BingoManager.OnBingoNumber += (number) =>
        {
            currentNumberText.text = number.ToString();
        };
        subInfoText.text = "";
        BingoManager.OnChangeSubInfoText += (text) =>
        {
            subInfoText.text = text;
        };
    }
}
