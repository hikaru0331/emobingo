using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnimation : MonoBehaviour
{

    public RectTransform JoinButton;
    public RectTransform MakeButton;
    // Start is called before the first frame update
    void Start()
    {
        JoinButton.DOMoveX(0, 1.5f).SetEase(Ease.OutQuint);


        MakeButton.DOMoveX(0, 1.5f).SetEase(Ease.OutQuint); ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
