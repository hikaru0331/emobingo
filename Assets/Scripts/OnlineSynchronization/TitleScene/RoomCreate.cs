using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomCreate : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField roomIdImputField = default;
    [SerializeField] private TMP_InputField userNameImputField = default;
    [SerializeField] private TMP_InputField prizesInputField = default;

    [SerializeField] private Button createRoomButton = default;

    //private CanvasGroup canvasGroup;

    private void Start()
    {
        // パスワードを入力する前は、ルーム参加ボタンを押せないようにする
        createRoomButton.interactable = false;

        //　ルーム作成ボタンのインタラクティブを設定するためのリスナーを登録
        roomIdImputField.onValueChanged.AddListener(OnInputFieldsValueChanged);
        userNameImputField.onValueChanged.AddListener(OnInputFieldsValueChanged);
        prizesInputField.onValueChanged.AddListener(OnInputFieldsValueChanged);

        createRoomButton.onClick.AddListener(OnJoinRoomButtonClick);
    }

    private void OnInputFieldsValueChanged(string value)
    {
        // 各フィールドに値が入力されている時のみ、ルーム作成ボタンを押せるようにする
        if (userNameImputField.text != "" && prizesInputField.text != "")
        {
            // ルーム番号が4桁入力されている時のみ、ルーム作成ボタンを押せるようにする
            createRoomButton.interactable = (roomIdImputField.text.Length == 4);
        }
        else
        {
            createRoomButton.interactable = false;
        }
    }

    private void OnJoinRoomButtonClick()
    {
        // ルーム参加処理中は、入力できないようにする
        createRoomButton.interactable = false;

        // ルームを非公開に設定する（新規でルームを作成する場合）
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = false;

        // ルーム番号と同じ名前のルームに参加する（ルームが存在しなければ作成してから参加する）
        PhotonNetwork.CreateRoom(roomIdImputField.text, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // ルームへの参加が成功したら、UIを非表示にする
        gameObject.SetActive(false);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、パスワードを再び入力できるようにする
        roomIdImputField.text = string.Empty;
        // canvasGroup.interactable = true;
    }
}
