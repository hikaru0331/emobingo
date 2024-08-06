using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

public class BingoSquare
{
    public int number;
    public string name;
    public bool isOpen;
    public string emotion;
}

public class BingoManager : MonoBehaviourPunCallbacks
{
    public const int SQUARE_COUNT = 9;
    private List<BingoSquare> bingoSquareList = new List<BingoSquare>();
    [SerializeField] private CardAreaView cardAreaView;

    // メンバー変数を追加
    private List<int> bingoNumberBuffer = new List<int>();
    // staticなイベントを作成
    public static System.Action<string> OnChangeSubInfoText;
    private bool bingoLog = true;//ビンゴ表示用
    private APIClient apiClient;

    public User currentUser;

    private void Start()
    {
        //ルーム番号指定
        GetRoomJson(PhotonNetwork.CurrentRoom.Name);
    }

    // Room データの保存先
    public RoomDTO currentRoom;

    private void GetRoomJson(string roomId)
    {
        
        apiClient = gameObject.AddComponent<APIClient>();

        string url = $"https://die-webapi.azurewebsites.net/api/rooms/{roomId}";

        StartCoroutine(apiClient.GetRequest(url, (response) => {
            RoomDTO room = JsonUtility.FromJson<RoomDTO>(response);
            currentRoom = room;
            //結構むりやりjsonの受け取り待ってる
            NewGame();
        }));
    }

    private IEnumerator GetUserJson(string user_id,System.Action<User> callback)
    {
        apiClient = gameObject.AddComponent<APIClient>();

        string url = $"https://die-webapi.azurewebsites.net/api/users/{user_id}";

        yield return StartCoroutine(apiClient.GetRequest(url, (response) => {
            User user = JsonUtility.FromJson<User>(response);
            callback(user);
        }));
    }

    private IEnumerator GenerateBingoCard(System.Action onComplete = null)
    {
        bingoSquareList.Clear();
        bingoNumberBuffer.Clear();
        //最大値最小値決める
        // currentRoom の images 配列から image_id の最大値を取得する
        int maxImageId = 0;
        //コメントアウトの箇所はAPIから取得するときに外す
        foreach (var image in currentRoom.images)
        {
            if (int.Parse(image.image_id) > maxImageId)
            {
                maxImageId = int.Parse(image.image_id);
            }
        }

        Debug.Log("最大の image_id: " + maxImageId);
        
        maxImageId = Mathf.Max(maxImageId, SQUARE_COUNT);
        List<BingoSquare> tempList = new List<BingoSquare>();
        for (int i = 1; i <= maxImageId; i++)
        {
            BingoSquare bingoSquare = new BingoSquare();
            bingoSquare.number = i;
            bingoSquare.isOpen = false;
            //名前追加
            foreach (var image in currentRoom.images)
            {
                if (int.Parse(image.image_id) == i)
                {
                    bingoSquare.emotion = judge_emotion(image.emotion);
                    //ここわからん
                    yield return StartCoroutine(GetUserJson(image.user_id,(user) =>{
                        bingoSquare.name = user.name;
                    }));
                    break;
                }
            }
            tempList.Add(bingoSquare);
            bingoNumberBuffer.Add(i);
        }
        for (int i = 0; i < SQUARE_COUNT; i++)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            bingoSquareList.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex);
        }
        onComplete?.Invoke();
    }

    private IEnumerator StartNewGame()
    {
        yield return StartCoroutine(GenerateBingoCard(() => {
            for (int i = 0; i < SQUARE_COUNT; i++)
            {
                cardAreaView.SetCardEmotion(i, bingoSquareList[i].emotion);
                cardAreaView.SetCardName(i, bingoSquareList[i].name);
                cardAreaView.SetCardImage(i, bingoSquareList[i].number, currentRoom);
                cardAreaView.SetCardClose(i);
            }   
        }));
    }

    // NewGameメソッドをRPCで呼び出すためのメソッド。BingoCardPanel > areaButton > newGameButtonで呼び出す
    public void CallNewGameRPC()
    {
        photonView.RPC(nameof(NewGame), RpcTarget.All);
    }

    [PunRPC]
    private void NewGame()
    {
        OnChangeSubInfoText?.Invoke("");
        StartCoroutine(StartNewGame());
    }
    
    private int GetRandomNumber()
    {
        if (bingoNumberBuffer.Count == 0)
        {
            return -1;
        }
        int randomIndex = Random.Range(0, bingoNumberBuffer.Count);
        int bingoNumber = bingoNumberBuffer[randomIndex];
        bingoNumberBuffer.RemoveAt(randomIndex);
        return bingoNumber;
    }

    // イベント発信用のアクションを追加
    public static System.Action<int,Sprite> OnBingoNumber;
    private IEnumerator DownloadImage(string url, int cardIndex)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            // イベント発信
            OnBingoNumber?.Invoke(cardIndex, sprite);
        }
    }
    public static System.Action<string> OnChangeAreaName;
    public static System.Action<string> OnBingoEmotion;
    private IEnumerator GetCurrentName(string user_id,string emotion)
    {
        string url = $"https://die-webapi.azurewebsites.net/api/users/{user_id}";
        UnityWebRequest www = UnityWebRequest.Get(url);
        string function_key = MyKey.function_key;
        www.SetRequestHeader("x-functions-key",function_key);
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            User user = JsonUtility.FromJson<User>(www.downloadHandler.text);
            OnChangeAreaName?.Invoke(user.name);

            OnBingoEmotion?.Invoke(judge_emotion(emotion));
        }
    }
    public string judge_emotion(string emotion)
    {
        if (emotion == "smile")
        {
            return "笑";
        }else if (emotion == "angry")
        {
            return "怒";
        }else{
            return "哀";
        }

    }

    // NewGameメソッドをRPCで呼び出すためのメソッド。BingoCardPanel > areaButton > nextButtonで呼び出す
    public void CallNextRPC()
    {
        OnChangeSubInfoText?.Invoke("");
        // まだ空いていないSquareを探す
        int number = GetRandomNumber();

        photonView.RPC(nameof(Next), RpcTarget.All, number);
    }

    [PunRPC]
    private void Next(int number)
    {
        // ここで数字から画像と名前、感情の情報を取得して表示する
        foreach (var image in currentRoom.images)
        {
            if (int.Parse(image.image_id) == number)
            {
                // コルーチンで非同期にリクエストを処理
                StartCoroutine(DownloadImage(image.url, number));
                StartCoroutine(GetCurrentName(image.user_id,image.emotion));
                break;
            }
        }

        // 数字から何番目のSquareのIndexかを探す
        int squareIndex = bingoSquareList.FindIndex(x => x.number == number);
        //Debug.Log($"Found square index: {squareIndex} for number: {number}");
        // 要素内に存在しない場合はエラー
        if (squareIndex == -1)
        {
            Debug.Log($"number:{number} squareIndex:{squareIndex}");
            return;
        }
        // 表示更新
        cardAreaView.SetCardOpen(squareIndex);
        // 変数の更新
        bingoSquareList[squareIndex].isOpen = true;
        IsBingo(squareIndex);
        if (IsBingo(squareIndex) && bingoLog)
        {
            // ここでSubInfo向けに変更したい文字を入力Bingo!!にしたりして見てください
            // ちなみにTextMeshProの関係で、日本語は使えないぞ！
            OnChangeSubInfoText?.Invoke("BINGO");
            Debug.Log("Bingo!(Nextメソッドのログを修正)");
            FindObjectOfType<BingoTextAnimation>().textAnime();
            bingoLog = false;
        }
    }
    
    public bool IsBingo(int squareIndex)
    {
        // まずはsquareIndexが有効かを確認する
        if (squareIndex < 0 || squareIndex >= SQUARE_COUNT)
        {
            return false;
        }
        // そのsquareが開いているかを確認する
        if (!bingoSquareList[squareIndex].isOpen)
        {
            return false;
        }
        // そのsquareがBingoになっているかを確認する
        int row = squareIndex / 3;
        int col = squareIndex % 3;
        // 横の判定
        bool isBingo = true;
        for (int i = 0; i < 3; i++)
        {
            if (!bingoSquareList[row * 3 + i].isOpen)
            {
                isBingo = false;
                break;
            }
        }
        if (isBingo)
        {
            Debug.Log("横の判定");
            return true;
        }
         // 縦の判定
        isBingo = true;
        for (int i = 0; i < 3; i++)
        {
            if (!bingoSquareList[col + i * 3].isOpen)
            {
                isBingo = false;
                break;
            }
        }
        if (isBingo)
        {
            Debug.Log("縦の判定");
            return true;
        }
        // 右下がり：左上から右下の斜め判定
        isBingo = true;
        for (int i = 0; i < 3; i++)
        {
            if (!bingoSquareList[i * 4].isOpen)
            {
                isBingo = false;
                break;
            }
        }
        if (isBingo)
        {
            Debug.Log("右下がり：左上から右下の斜め判定");
            return true;
        }

        // 右上がり：右上から左下の斜め判定
        isBingo = true;
        for (int i = 0; i < 3; i++)
        {
            if (!bingoSquareList[(i + 1) * 2].isOpen)
            {
                isBingo = false;
                break;
            }
        }
        if (isBingo)
        {
            Debug.Log("右上がり：右上から左下の斜め判定");
            return true;
        }
        return false;
    }
}