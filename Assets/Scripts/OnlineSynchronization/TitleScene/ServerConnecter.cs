using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ServerConnecter : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
}
