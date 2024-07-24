using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnimation : MonoBehaviour
{

    public RectTransform JoinButton;
    public RectTransform MakeButton;
    public RectTransform RoomJoinPanel;
    public RectTransform RoomCreatePanel;
    // Start is called before the first frame update
    void Start()
    {
        JoinButton.DOMoveX(0, 1.5f).SetEase(Ease.OutQuint);


        MakeButton.DOMoveX(0, 1.5f).SetEase(Ease.OutQuint); ;
    }

    public void RoomJoinAnimation()
    {
        RoomJoinPanel.DOMoveX(0, 1.5f).SetEase(Ease.OutQuint);
    }
    public void RoomJoinOffAnimation()
    {
        RoomJoinPanel.DOMoveX(3.0f, 1.5f).SetEase(Ease.OutQuint);
    }

    public void RoomCreateAnimation()
    {
        RoomCreatePanel.DOMoveX(0, 1.5f).SetEase(Ease.OutQuint);
    }
    public void RoomCreateOffAnimation()
    {
        RoomCreatePanel.DOMoveX(3.0f, 1.5f).SetEase(Ease.OutQuint);
    }
}
