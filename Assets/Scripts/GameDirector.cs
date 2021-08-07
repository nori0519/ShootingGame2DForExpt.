using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    public PlayerScript player;
    public Player2Script player2;
    public BulletGenerator bullet;
    public BulletGenerator2 bullet2;

    //UI
    //UIの非表示
    GameObject emo_img;
    GameObject webcam;
    GameObject score_con;
    GameObject score_con2;

    //Timeを代入するためのtimerText変数を宣言している。
    GameObject timeText;
    //残り時間用のtime変数を初期化する。
    static public float time;

    //scoreを代入するためのpointText_red,pointText_blue変数を宣言している
    GameObject scoreText_red;
    GameObject scoreText_blue;
    //score_red,score_blue
    int score_red = 0;
    int score_blue = 0;


    /// <summary>
    /// メソッド
    /// スコアを加算
    /// </summary>
    public void ScorePlus_r() {
        this.score_red += 100;
    }
    public void ScorePlus_b() {
        this.score_blue += 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        //シーンビューからUI部品の実態を検索してtimerText変数に代入
        this.timeText = GameObject.Find("Time");
        //シンビューからUI部品の実施を検索して,pointText_red,pointText_blue変数に代入
        this.scoreText_red = GameObject.Find("Score_red");
        this.scoreText_blue = GameObject.Find("Score_blue");
        //シーンビューからUI部品の実体を検索して、それぞれの変数に代入（非表示用）
        this.score_con = GameObject.Find("Score_con");
        this.score_con2 = GameObject.Find("Score_con2");
        this.emo_img = GameObject.Find("emotion_image");
        this.webcam = GameObject.Find("WebCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //UIの非表示
        //感情の非表示
        if (GameSettingController.emotion_disp == false) {
            emo_img.SetActive(false);//非表示
            webcam.SetActive(false);
        }
        else {
            emo_img.SetActive(true);//表示
            webcam.SetActive(true);
        }
        if (GameSettingController.score_disp==false) {
            scoreText_red.SetActive(false);
            scoreText_blue.SetActive(false);
            score_con.SetActive(false);
            score_con2.SetActive(false);
        } else {
            scoreText_red.SetActive(true);
            scoreText_blue.SetActive(true);
            score_con.SetActive(true);
            score_con2.SetActive(true);
        }

        //フレーム間の時間の差分を減算
        if (time >= 0) {
            time -= Time.deltaTime;
            //残り時間をToStringメソッドで文字列に変換してUIのTextに代入
            //小数点以下第一位まで表示するのでToStringの引数に「F」の文字列を指定
            this.timeText.GetComponent<Text>().text = time.ToString("F1");
        }else{
            //時間切れの時、playerの動きを停止する
            player.Finished = true;
            player2.Finished2 = true;
            bullet.Finished_b = true;
            bullet2.Finished_b2 = true;
        }
        //スコアをUIのTextに代入
        this.scoreText_red.GetComponent<Text>().text = this.score_red.ToString() + "point";
        this.scoreText_blue.GetComponent<Text>().text = this.score_blue.ToString() + "point";
    }
}
