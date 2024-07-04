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
 
    public void BingoPanelView()
    {
        BingoPanel.SetActive(true);
        RandomPanel.SetActive(false);
    }
 
    public void RandomPanelView()
    {
        BingoPanel.SetActive(false);
        RandomPanel.SetActive(true);
    }
}