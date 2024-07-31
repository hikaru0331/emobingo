using Photon.Pun;
using TMPro;
using UnityEngine;

public class WaitingRoomController : MonoBehaviourPunCallbacks
{
   [SerializeField] private TextMeshProUGUI roomIdDiplayer = default;
   [SerializeField] private TextMeshProUGUI participantsDisplayer = default;

   private void OnEnable() 
   {
        roomIdDiplayer.text = PhotonNetwork.CurrentRoom.Name;
        
        photonView.RPC(nameof(UpdateUserList), RpcTarget.All);
   }
   
    [PunRPC]
    public void UpdateUserList() 
    {
        participantsDisplayer.text = "";
        foreach (var participants in PhotonNetwork.PlayerList) 
        {
            participantsDisplayer.text += participants.NickName + "\n";
        }
    }
}
