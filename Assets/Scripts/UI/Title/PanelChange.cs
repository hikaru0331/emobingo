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

    void Start()
    {
        mainPanel.SetActive(true);
        roominPanel.SetActive(false);
        roommakePanel.SetActive(false);
        themePanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        roominPanel.SetActive(false);
        roommakePanel.SetActive(false);
    }

    public void SubView()
    {
        mainPanel.SetActive(false);
        roominPanel.SetActive(true);
    }
    public void roommakeView()
    {
        mainPanel.SetActive(false);
        roommakePanel.SetActive(true);
    }
    public void ThemeView()
    {
        themePanel.SetActive(true);
        roommakePanel.SetActive(false);
        roominPanel.SetActive(false);
    }

}
