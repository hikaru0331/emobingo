using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public GameObject ExitPanel;

    // Start is called before the first frame update
    void Start()
    {
        ExitPanel.SetActive(false);
    }

    public void ExitView()
    {
        ExitPanel.SetActive(true);
    }
    public void RoomView()
    {
        ExitPanel.SetActive(false);
    }
}
