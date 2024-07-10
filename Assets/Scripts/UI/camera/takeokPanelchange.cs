using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class takeokPanelchange : MonoBehaviour
{
    public GameObject takePanel1;
    public GameObject okPanel1;
    public GameObject takePanel2;
    public GameObject okPanel2;
    public GameObject takePanel3;
    public GameObject okPanel3;

    void Start()
    {
        takePanel1.SetActive(true);
        okPanel1.SetActive(false);
        takePanel2.SetActive(true);
        okPanel2.SetActive(false);
        takePanel3.SetActive(true);
        okPanel3.SetActive(false);
    }

    public void take1View()
    {
        takePanel1.SetActive(true);
        okPanel1.SetActive(false);
    }

    public void ok1View()
    {
        takePanel1.SetActive(false);
        okPanel1.SetActive(true);
    }
    public void take2View()
    {
        takePanel2.SetActive(true);
        okPanel2.SetActive(false);
    }

    public void ok2View()
    {
        takePanel2.SetActive(false);
        okPanel2.SetActive(true);
    }
    public void take3View()
    {
        takePanel3.SetActive(true);
        okPanel3.SetActive(false);
    }

    public void ok3View()
    {
        takePanel3.SetActive(false);
        okPanel3.SetActive(true);
    }
}