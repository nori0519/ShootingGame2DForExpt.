using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class UserLocal : MonoBehaviour
{
    //web cam and RawImage  initiald
    //RawImageでWebカメラで取得した画像を貼り付ける。
    public RawImage rawImage;
    WebCamTexture webCamTexture;

    //時間間隔
    float timeElapsed;

    //textureをtexture2Dにする関数
    public Texture2D ToTexture2D(Texture self)
    {
        var sw = self.width;
        var sh = self.height;
        var format = TextureFormat.RGBA32;
        var result = new Texture2D(sw, sh, format, false);
        var currentRT = RenderTexture.active;
        var rt = new RenderTexture(sw, sh, 32);
        Graphics.Blit(self, rt);
        RenderTexture.active = rt;
        var source = new Rect(0, 0, rt.width, rt.height);
        result.ReadPixels(source, 0, 0);
        result.Apply();
        RenderTexture.active = currentRT;
        return result;
    }

    //Jsonで型を揃える
    [System.Serializable]
    public class MyJson
    {
        public string image_base64;
        public string api_key;
    }

    //emotionを格納する(クラブ内部のみアクセス可能)
    private String emotion_str;

    //image:感情によって絵文字的なものをここに表示させる。（例：surprise→驚いた画像）
    [SerializeField]
    public Image image;
    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {
        //カメラ起動、RawImageに表示
        webCamTexture = new WebCamTexture();
        rawImage.texture = webCamTexture;
        webCamTexture.Play();

        //emotionの初期化
        emotion_str = "neutral";
    }

    // Update is called once per frame
    void Update()
    {
        //一定の時間間隔での処理実行
        // 30000ms(30s)毎
        timeElapsed += Time.deltaTime;
        if (timeElapsed < 30f) return;
        timeElapsed = 0.0f;

        //1.取得したカメラ映像のフローについて
        //WebCamTexture>Texture2D>JPG形式>Base64形式
        //WebCamTexture>Texture2D
        var img2d = ToTexture2D(webCamTexture);
        //Texture2D>JPG形式>Base64形式(Convert.ToBase64StringメソッドでBase64形式に変換)
        //Texture2D>JPG→var img = img2d.EncodeToJPG();
        string enc = System.Convert.ToBase64String(img2d.EncodeToJPG());

        MyJson myObject = new MyJson();
        myObject.api_key = "511A418E72591EB7E33F703F04C3FA16DF6C90BD";
        myObject.image_base64 = enc;
        string myjson = JsonUtility.ToJson(myObject);

        StartCoroutine("PostData", myjson);
    }
    //<summary>
    //Base64に変換した画像と開発者ごとのAPIキーをHson形式に格納し、コルーチンでPostData()に渡す。
    //2.感情によってimageの画像を変更する
    //angry→angry.jpg
    //joy→joy.jpg
    //sadness→sadness.jpg
    //surprise→surprise.jpg
    //</summary>
    [Obsolete]
    IEnumerator PostData(string myjson)
    {
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(myjson);
        var request = new UnityWebRequest("https://face-ai.userlocal.jp/api/detect", "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.Send();

        //FaceEntityクラスへデータを格納する
        FaceEntity faceEntity = JsonUtility.FromJson<FaceEntity>(request.downloadHandler.text);
        string jsonText = request.downloadHandler.text;
        if(faceEntity.result[0].emotion.ToString() != null)
            emotion_str = faceEntity.result[0].emotion.ToString();

        //結果の表示
        Debug.Log(request.error);
        Debug.Log(request.downloadHandler.text);
        Debug.Log("emotion:" + emotion_str);

        //imageにemotion_strによって画像を切り替えるようにする
        if (emotion_str.Equals("angry"))
        {
            sprite = Resources.Load<Sprite>("angry");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (emotion_str.Equals("joy"))
        {

            sprite = Resources.Load<Sprite>("joy");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;

        }
        else if (emotion_str.Equals("sadness"))
        {
            sprite = Resources.Load<Sprite>("sadness");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else if (emotion_str.Equals("surprise"))
        {
            sprite = Resources.Load<Sprite>("surprise");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
        else
        {
            //neutral
            sprite = Resources.Load<Sprite>("neutral");
            //image = this.GetComponent<Image>();
            image.sprite = sprite;
        }
    }
}

//データを生成するクラスの生成
[System.Serializable]
public class FaceEntity
{
    public string id;
    public Result[] result;
}

[System.Serializable]
public class Result
{
    public string emotion;//感情値
    public int accuracy;//精度
}
