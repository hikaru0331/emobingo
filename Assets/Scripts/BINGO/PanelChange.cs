using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
 
public class PanelCange : MonoBehaviour
{
    [SerializeField] private GameObject BingoPanel;
    [SerializeField] private GameObject RandomPanel;
    [SerializeField] private Button bingoPanelNextButton = default;
    [SerializeField] private Button randomPanelNextButton = default;

    private void Update() 
    {
        if(PhotonNetwork.IsMasterClient) 
        {
            bingoPanelNextButton.interactable = true;
            randomPanelNextButton.interactable = true;
        }
        else 
        {
            bingoPanelNextButton.interactable = false;
            randomPanelNextButton.interactable = false;
        }
    }

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