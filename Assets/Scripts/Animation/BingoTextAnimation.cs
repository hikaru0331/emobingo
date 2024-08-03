using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class BingoTextAnimation : MonoBehaviour
{
    public TextMeshProUGUI tmpro;

    // Start is called before the first frame update
    public void textAnime()
    {
        DOTweenTMPAnimator textAnim = new DOTweenTMPAnimator(tmpro);
        for (int iCnt = 0; iCnt < textAnim.textInfo.characterCount; iCnt++)
        {
            textAnim.DOPunchCharOffset(iCnt, Vector3.up * 30.0f, 1.0f, 3).SetDelay(0.1f * iCnt).SetLoops(-1);
        }
    }
}
