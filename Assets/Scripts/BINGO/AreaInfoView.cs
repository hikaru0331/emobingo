using UnityEngine;
using TMPro;

public class AreaInfoView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentNumberText;
    [SerializeField] private UnityEngine.UI.Image currentImage;
    public TextMeshProUGUI CurrentNumberText => currentNumberText;
    public UnityEngine.UI.Image CurrentImage => currentImage;
    
    //ここでこの数字のImageも入れるコード追加したい
    private void Start()
    {
        BingoManager.OnBingoNumber += (number) =>
        {
            currentNumberText.text = number.ToString();
        };
    }
}