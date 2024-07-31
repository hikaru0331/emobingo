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
        
        participantsDisplayer.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
   }
}
