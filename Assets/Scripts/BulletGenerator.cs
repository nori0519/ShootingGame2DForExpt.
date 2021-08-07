using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    //弾オブジェクト
    public GameObject bulletPrefab;
    //プレイヤオブジェクト
    GameObject player;
    //時間切れかどうか判定する変数の宣言
    public bool Finished_b { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        //ヒエラルキーからプレイヤーオブジェクト検索
        this.player = GameObject.Find("player");
        //時間切れかどうかの判定変数の初期化
        Finished_b = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            if (Finished_b == false)
            {
                //弾を定義
                GameObject bullet = Instantiate(bulletPrefab) as GameObject;
                // 弾をプレイヤーの中心座標から生成
                bullet.transform.position = new Vector2(this.player.transform.position.x + 0.45f, this.player.transform.position.y + 0.5f);
            }
        }
    }
}
