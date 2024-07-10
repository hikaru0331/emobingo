using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartButton : MonoBehaviour
{
    public GameObject button_start;
    

    public void GameStartButtonOff()
    {
        button_start.SetActive(false);
    }
    public void GameStartButtonOn()
    {
        button_start.SetActive(true);
    }
}
