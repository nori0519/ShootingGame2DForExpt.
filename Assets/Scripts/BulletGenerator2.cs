using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator2 : MonoBehaviour
{
    //弾オブジェクト
    public GameObject bulletPrefab;
    //プレイヤオブジェクト
    GameObject player2;

    //時間切れかどうか判定する変数の宣言
    public bool Finished_b2 { get; set; }

    //時間間隔の変数
    float timeElapsed;
    //時間間隔の秒数 timeout
    static public float timeout;

    // Start is called before the first frame update
    void Start()
    {
        //ヒエラルキーからプレイヤー2オブジェクト検索
        this.player2 = GameObject.Find("player2");
        //時間切れかどうかの判定変数の初期化
        Finished_b2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //for Debug
        // コンソールにhitしたGameObjectを出力
        //Debug.Log(hit.collider);
    }

    private void FixedUpdate()
    {
        //transformの取得
        Transform transform = player2.transform;
        //座標の取得
        Vector3 pos = transform.position;
        //y軸にずらす
        pos.y = pos.y - 1;
        //RaycastHit取得
        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, -1, 0), 100);
        //outwall2を目の前に接触すれば発射する
        if (hit.collider.CompareTag("outwall2"))
        {
            if (Finished_b2 == false)
            {
                //一定の時間間隔での処理実行
                // 普通：10000ms(1s)毎 or　強い：0.3s毎
                timeElapsed += Time.deltaTime;
                if (timeElapsed < timeout) return;
                timeElapsed = 0.0f;

                //弾を定義
                GameObject bullet2 = Instantiate(bulletPrefab) as GameObject;
                // 弾をプレイヤーの中心座標から生成
                bullet2.transform.position = new Vector2(this.player2.transform.position.x + 0.45f, this.player2.transform.position.y - 1);
            }
        }
        if (hit.collider.CompareTag("player"))
        {
            if (Finished_b2 == false)
            {
                //一定の時間間隔での処理実行
                // 普通：10000ms(1s)毎 or　強い：0.3s毎
                timeElapsed += Time.deltaTime;
                if (timeElapsed < timeout) return;
                timeElapsed = 0.0f;

                //弾を定義
                GameObject bullet2 = Instantiate(bulletPrefab) as GameObject;
                // 弾をプレイヤーの中心座標から生成
                bullet2.transform.position = new Vector2(this.player2.transform.position.x + 0.45f, this.player2.transform.position.y - 1);
            }
        }
    }
}
