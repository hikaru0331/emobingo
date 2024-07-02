using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PanelCange : MonoBehaviour
{
    public GameObject TitlePanel;
    public GameObject CreateRoomPanel;
 
    void Start()
    {
        TitlePanel.SetActive(true);
        CreateRoomPanel.SetActive(false);
    }
 
    public void MainView()
    {
        TitlePanel.SetActive(true);
        CreateRoomPanel.SetActive(false);
    }
 
    public void SubView()
    {
        TitlePanel.SetActive(false);
        CreateRoomPanel.SetActive(true);
    }
}