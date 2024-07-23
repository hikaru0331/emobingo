using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    public RawImage Cam1Image; // RawImageコンポーネントの参照
    public RawImage Check1Image; // RawImageコンポーネントの参照
    public RawImage Cam2Image; // RawImageコンポーネントの参照
    public RawImage Check2Image; // RawImageコンポーネントの参照
    public RawImage Cam3Image; // RawImageコンポーネントの参照
    public RawImage Check3Image; // RawImageコンポーネントの参照
    
    private WebCamTexture webCamTexture;
    private Texture2D capturedImage;


    public void Cam1Start(){
                // デバイスのカメラ一覧を取得
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            // 最初のカメラを使用
            webCamTexture = new WebCamTexture(devices[0].name);
            webCamTexture.Play();
            Cam1Image.texture = webCamTexture;
        }
        else
        {
            Debug.LogError("カメラが見つかりませんでした。");
        }
    }

    public void Cam2Start(){
                // デバイスのカメラ一覧を取得
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            // 最初のカメラを使用
            webCamTexture = new WebCamTexture(devices[0].name);
            webCamTexture.Play();
            Cam2Image.texture = webCamTexture;
        }
        else
        {
            Debug.LogError("カメラが見つかりませんでした。");
        }
    }

    public void Cam3Start(){
                // デバイスのカメラ一覧を取得
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length > 0)
        {
            // 最初のカメラを使用
            webCamTexture = new WebCamTexture(devices[0].name);
            webCamTexture.Play();
            Cam3Image.texture = webCamTexture;
        }
        else
        {
            Debug.LogError("カメラが見つかりませんでした。");
        }
    }

    public void TakeShot1()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            // カメラの映像をキャプチャ
            capturedImage = new Texture2D(webCamTexture.width, webCamTexture.height);
            capturedImage.SetPixels(webCamTexture.GetPixels());
            capturedImage.Apply();

            // キャプチャした画像をRawImageに設定
            Check1Image.texture = capturedImage;

            // カメラを停止
            webCamTexture.Stop();
        }
    }
    public void TakeShot2()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            // カメラの映像をキャプチャ
            capturedImage = new Texture2D(webCamTexture.width, webCamTexture.height);
            capturedImage.SetPixels(webCamTexture.GetPixels());
            capturedImage.Apply();

            // キャプチャした画像をRawImageに設定
            Check2Image.texture = capturedImage;

            // カメラを停止
            webCamTexture.Stop();
        }
    }
    public void TakeShot3()
    {
        if (webCamTexture != null && webCamTexture.isPlaying)
        {
            // カメラの映像をキャプチャ
            capturedImage = new Texture2D(webCamTexture.width, webCamTexture.height);
            capturedImage.SetPixels(webCamTexture.GetPixels());
            capturedImage.Apply();

            // キャプチャした画像をRawImageに設定
            Check3Image.texture = capturedImage;

            // カメラを停止
            webCamTexture.Stop();
        }
    }

    

}
