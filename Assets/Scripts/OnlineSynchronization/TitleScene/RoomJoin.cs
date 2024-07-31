using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomJoin : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomIdImputField = default;
    [SerializeField] private TMP_InputField userNameImputField = default;

    [SerializeField] private Button joinRoomButton = default;

    [SerializeField] private GameObject ThemePanel;

    private void Start()
    {
        // パスワードを入力する前は、ルーム参加ボタンを押せないようにする
        joinRoomButton.interactable = false;

        //　ルーム作成ボタンのインタラクティブを設定するためのリスナーを登録
        roomIdImputField.onValueChanged.AddListener(OnInputFieldsValueChanged);
        userNameImputField.onValueChanged.AddListener(OnInputFieldsValueChanged);

        joinRoomButton.onClick.AddListener(OnConfirmButtonClicked);
    }

    private void OnInputFieldsValueChanged(string value)
    {
        // ユーザー名入力フィールドに値が入力されている時のみ、ルーム作成ボタンを押せるようにする
        if (userNameImputField.text != "")
        {
            // ルーム番号が4桁入力されている時のみ、ルーム作成ボタンを押せるようにする
            joinRoomButton.interactable = (roomIdImputField.text.Length == 4);
        }
        else
        {
            joinRoomButton.interactable = false;
        }
    }

    private void OnConfirmButtonClicked()
    {
        // ルーム参加処理中は、入力できないようにする
        joinRoomButton.interactable = false;

        // プレイヤーのカスタムプロパティにユーザー名を設定
        PhotonNetwork.LocalPlayer.SetUserName(userNameImputField.text);

        // ルーム番号と同じ名前のルームを作成する
        PhotonNetwork.JoinRoom(roomIdImputField.text);
    }

    public override void OnJoinedRoom()
    {
        // ルームへの参加が成功したら、次のパネルを表示する
        gameObject.SetActive(false);
        ThemePanel.SetActive(true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、パスワードを再び入力できるようにする
        roomIdImputField.text = string.Empty;
        Debug.Log($"ルームへの参加に失敗しました: {message}");
    }
}
