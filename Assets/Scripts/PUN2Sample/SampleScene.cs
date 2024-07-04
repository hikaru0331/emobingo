using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace PUN2Sample
{    
    public class SampleScene : MonoBehaviourPunCallbacks
    {
        private void Start() 
        {
            // プレイヤー自身の名前を"Player"に設定する
            PhotonNetwork.NickName = "Player";

            // プレイヤーのカスタムプロパティに、ランダムなランクを設定する
            PhotonNetwork.LocalPlayer.SetRandomRank();

            // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
            PhotonNetwork.ConnectUsingSettings();
        }

        // マスターサーバーへの接続が成功した時に呼ばれるコールバック
        public override void OnConnectedToMaster() 
        {
            var expectedProps = new Hashtable();
            expectedProps.SetPlayerRank(PhotonNetwork.LocalPlayer);

            // 自身と同じランクのプレイヤーが作成したルームへランダムに参加する
            PhotonNetwork.JoinRandomRoom(expectedProps, 2);
        }

         // ランダムで参加できるルームが存在しないなら、新規でルームを作成する
        public override void OnJoinRandomFailed(short returnCode, string message) 
        {
            // ルームのカスタムプロパティの初期値に、自身と同じランクを設定する
            var initialProps = new Hashtable();
            initialProps.SetPlayerRank(PhotonNetwork.LocalPlayer);

            // ルーム設定を行う
            var roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 2;
            roomOptions.CustomRoomProperties = initialProps;
            roomOptions.CustomRoomPropertiesForLobby = initialProps.KeysForLobby();

            PhotonNetwork.CreateRoom(null, roomOptions);
        }

        // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
        public override void OnJoinedRoom()
        {
            // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
            var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);

            // ルームを作成したプレイヤーは、現在のサーバー時刻をゲームの開始時刻に設定する
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.CurrentRoom.SetStartTime(PhotonNetwork.ServerTimestamp);
            }

            // ルームが満員になったら、以降そのルームへの参加を不許可にする
            if (PhotonNetwork.CurrentRoom.PlayerCount == PhotonNetwork.CurrentRoom.MaxPlayers)
            {
                PhotonNetwork.CurrentRoom.IsOpen = false;
            }
        }
    }
}
