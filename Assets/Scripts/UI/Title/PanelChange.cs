using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject roominPanel;
    public GameObject roommakePanel;
    public GameObject themePanel;
    public GameObject takephotoPanel1;
    public GameObject takephotoPanel2;
    public GameObject takephotoPanel3;
    public GameObject roomPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        roominPanel.SetActive(false);
        roommakePanel.SetActive(false);
        themePanel.SetActive(false);
        takephotoPanel1.SetActive(false);
        takephotoPanel2.SetActive(false);
        takephotoPanel3.SetActive(false);
        roomPanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        roominPanel.SetActive(false);
        roommakePanel.SetActive(false);
        themePanel.SetActive(false);
        takephotoPanel1.SetActive(false);
        takephotoPanel2.SetActive(false);
        takephotoPanel3.SetActive(false);
        roomPanel.SetActive(false);
    }

    public void SubView()
    {
        mainPanel.SetActive(false);
        roominPanel.SetActive(true);
    }
    public void RoomMakeView()
    {
        mainPanel.SetActive(false);
        roommakePanel.SetActive(true);
    }
    
    // ルーム作成の時点でUIを非表示にしたいため、コメントアウト
    // public void ThemeView()
    // {
    //     themePanel.SetActive(true);
    //     roommakePanel.SetActive(false);
    //     roominPanel.SetActive(false);
    // }
    
    public void Camera1View()
    {
        takephotoPanel1.SetActive(true);
        themePanel.SetActive(false);
    }
    public void Camera2View()
    {
        takephotoPanel2.SetActive(true);
        takephotoPanel1.SetActive(false);
    }
    public void Camera3View()
    {
        takephotoPanel3.SetActive(true);
        takephotoPanel2.SetActive(false);
    }
    public void RoomView()
    {
        roomPanel.SetActive(true);
        takephotoPanel3.SetActive(false);
    }
}
