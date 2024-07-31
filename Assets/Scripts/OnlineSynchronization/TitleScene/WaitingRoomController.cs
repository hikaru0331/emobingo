using System;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class WaitingRoomController : MonoBehaviourPunCallbacks
{
   [SerializeField] private TextMeshProUGUI roomIdDiplayer = default;
   [SerializeField] private TextMeshProUGUI participantsDisplayer = default;

   private void OnEnable() 
   {
        var token = this.GetCancellationTokenOnDestroy();
        roomIdDiplayer.text = PhotonNetwork.CurrentRoom.Name;
        
        photonView.RPC(nameof(UpdateUserList), RpcTarget.All);
   }

    private void OnDisable() 
    {
        photonView.RPC(nameof(UpdateUserList), RpcTarget.All);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateUserList();
    }

    [PunRPC]
    public async void UpdateUserList() 
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f));
        
        Debug.Log("UpdateUserList");
        participantsDisplayer.text = "";
        foreach (var participants in PhotonNetwork.PlayerList) 
        {
            participantsDisplayer.text += participants.NickName + "\n";
        }
    }
}
