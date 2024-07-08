using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoPanel : MonoBehaviour
{
    public GameObject takePanel;
    public GameObject okPanel;

    void Start()
    {
        takePanel.SetActive(true);
        okPanel.SetActive(false);
    }

    public void takeView()
    {
        takePanel.SetActive(true);
        okPanel.SetActive(false);
    }

    public void okView()
    {
        takePanel.SetActive(false);
        okPanel.SetActive(true);
    }
}