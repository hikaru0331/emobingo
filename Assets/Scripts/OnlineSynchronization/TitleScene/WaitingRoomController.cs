using System;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

public class WaitingRoomController : MonoBehaviourPunCallbacks
{
   [SerializeField] private TextMeshProUGUI roomIdDiplayer = default;
   [SerializeField] private TextMeshProUGUI participantsDisplayer = default;
   [SerializeField] private Button gameStartButton = default;
   [SerializeField] private RoomManager roomManager = default;

    private void Update() 
    {
        if(PhotonNetwork.IsMasterClient) 
        {
            gameStartButton.interactable = true;
        }
        else 
        {
            gameStartButton.interactable = false;
        }    
    }

   private void OnEnable() 
   {
        var token = this.GetCancellationTokenOnDestroy();
        roomIdDiplayer.text = PhotonNetwork.CurrentRoom.Name;

        gameStartButton.onClick.AddListener(StartGame);
                
        photonView.RPC(nameof(UpdateUserList), RpcTarget.All);
   }

    private void OnDisable() 
    {
        photonView.RPC(nameof(UpdateUserList), RpcTarget.All);
    }

    // なぜか呼ばれない…
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        UpdateUserList();
    }

    [PunRPC]
    private async void UpdateUserList() 
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f));
        
        Debug.Log("UpdateUserList");
        participantsDisplayer.text = "";
        foreach (var participants in PhotonNetwork.PlayerList) 
        {
            participantsDisplayer.text += participants.NickName + "\n";
        }
    }

    private async void StartGame() 
    {       
        //　ルームの情報をバックエンドにポストする
        PostRoom postRoom = new PostRoom{room_id = PhotonNetwork.CurrentRoom.Name};
        roomManager.CreateRoom(postRoom);

        //　画像ポストを待つためにここで1秒待つ
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        
        PhotonNetwork.LoadLevel("BINGO");
    }
}
