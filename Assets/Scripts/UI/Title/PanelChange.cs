using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject roommakePanel;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        roommakePanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        roommakePanel.SetActive(false);
    }

    public void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
    }
    public void roommakeView()
    {
        mainPanel.SetActive(false);
        roommakePanel.SetActive(true);
    }


}
