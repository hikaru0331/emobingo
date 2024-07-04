using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PanelCange : MonoBehaviour
{
    public GameObject BingoPanel;
    public GameObject RandomPanel;
 
    void Start()
    {
        BingoPanel.SetActive(true);
        RandomPanel.SetActive(false);
    }
 
    public void MainView()
    {
        BingoPanel.SetActive(true);
        RandomPanel.SetActive(false);
    }
 
    public void SubView()
    {
        BingoPanel.SetActive(false);
        RandomPanel.SetActive(true);
    }
}