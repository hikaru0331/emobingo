using Photon.Pun;
using TMPro;
using UnityEngine;

public class WaitingRoomController : MonoBehaviourPunCallbacks
{
   [SerializeField] private TextMeshProUGUI roomIdDiplayer = default;

   private void OnEnable() 
   {
        roomIdDiplayer.text = PhotonNetwork.CurrentRoom.Name;
   }
}
