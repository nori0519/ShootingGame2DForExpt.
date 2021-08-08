using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //時間切れかどうか判定する変数の宣言
    public bool Finished { get; set; }

    //Rigidbody2Dを宣言する
    Rigidbody2D rigid2D;

    //GameDirectorオブジェクトの宣言
    GameObject director;

    // Start is called before the first frame update
    void Start()
    { 
        //時間切れかどうかの判定変数の初期化
        Finished = false;
        //Rigidbody2Dコンポーネントの呼び出し
        this.rigid2D = GetComponent<Rigidbody2D>();

        //「GameDirector」スクリプトが持つメソッド（スコア加算）を呼び出すため、監督オブジェクトをシーンビューからFindメソッドで検索
        this.director = GameObject.Find("GameDirector");
    }
    // Update is called once per frame
    void Update()
    {
        //制限時間切れになれば、操作を中止
        if (Finished == false)
        {
            // 操作
            var hori = Input.GetAxis("Horizontal");
            var vert = Input.GetAxis("Vertical");

            rigid2D.velocity = new Vector2(hori, vert) * 5;
        }else {
            rigid2D.velocity = Vector2.zero;
            rigid2D.angularVelocity = 0f;
        }
    }

    //当たり判定
    //相手の弾に当たれば、スコアの更新と初期位置にテレポート
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.tag == "bullet2") {
            //非表示
            gameObject.SetActive(false);
            //ポイントを更新
            this.director.GetComponent<GameDirector>().ScorePlus_r();
            //初期位置にテレポート
            gameObject.transform.position = new Vector3(-3, -3, 0);
            //表示
            gameObject.SetActive(true);
        }
    }
   
}
