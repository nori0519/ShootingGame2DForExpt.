using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingController : MonoBehaviour
{
    //Dropdownを格納する変数
    [SerializeField]
    public Dropdown emotion;
    [SerializeField]
    public Dropdown time;
    [SerializeField]
    public Dropdown score;
    [SerializeField]
    public Dropdown power;
    [SerializeField]
    public Dropdown pattern;

    //GameObjectの表示・非表示を格納する変数
    static public bool emotion_disp;//相手の表情の非表示
    static public bool score_disp;//スコアの非表示
    //パターンを格納する変数宣言
    static public int pattern_num;//パターン


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //感情の推定を表示するか否か
        if (emotion.value == 0 ) {
            emotion_disp = true;
        }
        else{
            emotion_disp = false;
        }
        //タイムリミットを長くするか短くするか
        if (time.value == 0)
        {
            //GameDirectorスクリプトからtime変数を呼び出す。
            GameDirector.time = 60.0f;
        }
        else {
            GameDirector.time = 30.0f;
        }
        //スコアを表示するか非表示にするか
        if (score.value == 0) {
            score_disp = true;
        }
        else {
            score_disp = false;
        }
        //敵キャラの強さをどうするか
        if (power.value==0) {
            //Player2Scriptスクリプトからspeed_p2変数を呼び出し
            Player2Script.speed_p2 =1;
            //BulletScript2スクリプトからspeed_b2変数を呼び出し
            BulletScript2.speed_b2 = -5.0f;
            //BulletGenerator2スクリプトからtimeout変数を呼び出し
            //弾の発射間隔を設定
            BulletGenerator2.timeout = 0.3f;
        }
        else {
            Player2Script.speed_p2 = 1;
            BulletScript2.speed_b2 = -3.0f;
            BulletGenerator2.timeout = 1.0f;
        }
        //パターンをどれにするか（剰余変数を防ぐ、自らの気分などによる）
        if (pattern.value == 0)
        {
            pattern_num = 0;
        }
        else if (pattern.value == 1)
        {
            pattern_num = 1;
        }
        else if (pattern.value == 2)
        {
            pattern_num = 3;
        }
        else if (pattern.value == 3)
        {
            pattern_num = 3;
        }
        else if (pattern.value == 4)
        {
            pattern_num = 4;
        }
        else if (pattern.value == 5)
        {
            pattern_num = 5;
        }
        else if (pattern.value == 6)
        {
            pattern_num = 6;
        }
        else if (pattern.value == 7)
        {
            pattern_num = 7;
        }
        else if (pattern.value == 8)
        {
            pattern_num = 8;
        }
        else if (pattern.value == 9)
        {
            pattern_num = 9;
        }
        else if (pattern.value == 10)
        {
            pattern_num = 10;
        }
        else if (pattern.value == 11)
        {
            pattern_num = 11;
        }
        else if (pattern.value == 12)
        {
            pattern_num = 12;
        }
        else if (pattern.value == 13)
        {
            pattern_num = 13;
        }
        else if (pattern.value == 14)
        {
            pattern_num = 14;
        }
        else
        {
            pattern_num = 15;
        }

    }
}
