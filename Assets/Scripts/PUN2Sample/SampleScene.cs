using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PUN2Sample
{    
    public class SampleScene : MonoBehaviourPunCallbacks
    {
        private void Start() {
            // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
            PhotonNetwork.ConnectUsingSettings();
        }

        // マスターサーバーへの接続が成功した時に呼ばれるコールバック
        public override void OnConnectedToMaster() {
            // "Room"という名前のルームに参加する（ルームが存在しなければ作成して参加する）
            PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
        }

        // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
        public override void OnJoinedRoom() {
            // ランダムな座標に自身のアバター（ネットワークオブジェクト）を生成する
            var position = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            PhotonNetwork.Instantiate("Avatar", position, Quaternion.identity);
        }
    }
}