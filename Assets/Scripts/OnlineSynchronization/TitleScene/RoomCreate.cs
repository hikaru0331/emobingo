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

    [SerializeField] private GameObject ThemePanel;

    //private CanvasGroup canvasGroup;

    private void Start()
    {
        // パスワードを入力する前は、ルーム参加ボタンを押せないようにする
        createRoomButton.interactable = false;

        //　ルーム作成ボタンのインタラクティブを設定するためのリスナーを登録
        roomIdImputField.onValueChanged.AddListener(OnInputFieldsValueChanged);
        userNameImputField.onValueChanged.AddListener(OnInputFieldsValueChanged);
        prizesInputField.onValueChanged.AddListener(OnInputFieldsValueChanged);

        createRoomButton.onClick.AddListener(OnConfirmButtonClicked);
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

    private void OnConfirmButtonClicked()
    {
        // ルーム参加処理中は、入力できないようにする
        createRoomButton.interactable = false;

        // プレイヤーのカスタムプロパティにユーザー名を設定
        PhotonNetwork.LocalPlayer.SetUserName(userNameImputField.text);

        // ルーム番号と同じ名前のルームを作成する
        PhotonNetwork.CreateRoom(roomIdImputField.text);
    }

    public override void OnCreatedRoom()
    {
        // ルームのカスタムプロパティに景品の最大数を設定
        PhotonNetwork.CurrentRoom.SetPrizesMaximun(int.Parse(prizesInputField.text));
         
        // 景品数のプロパティがうまく設定されてなさそう…？
        Debug.Log(int.Parse(prizesInputField.text));
        Debug.Log(PhotonNetwork.CurrentRoom.GetPrizesMaximun());

        // ルームへの参加が成功したら、次のパネルを表示する
        gameObject.SetActive(false);
        ThemePanel.SetActive(true);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、パスワードを再び入力できるようにする
        roomIdImputField.text = string.Empty;
        Debug.Log($"ルームへの参加に失敗しました: {message}");
    }
}
