using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
 
public class PanelCange : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject BingoPanel;
    [SerializeField] private GameObject RandomPanel;
    [SerializeField] private Button bingoPanelNextButton = default;
    [SerializeField] private Button randomPanelNextButton = default;

    //マスタークライアントのみボタンを有効化できるように
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

    public void CallChangePanelRPC()
    {
        photonView.RPC(nameof(ChangePanelRPC), RpcTarget.All);
    }

    [PunRPC]
    public void ChangePanelRPC()
    {
        BingoPanel.SetActive(!BingoPanel.activeSelf);
        RandomPanel.SetActive(!RandomPanel.activeSelf);
    }
}