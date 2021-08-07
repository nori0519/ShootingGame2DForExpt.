using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBulletGeneratorScript : MonoBehaviour
{
    //弾オブジェクト
    public GameObject bulletPrefab;
    //プレイヤオブジェクト
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //ヒエラルキーから該当オブジェクト検索
        //プレイヤ
        this.player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            //弾を定義
            GameObject bullet = Instantiate(bulletPrefab) as GameObject;
            //弾をプレイヤの中心座標から生成
            bullet.transform.position = new Vector2(this.player.transform.position.x + 0.45f, this.player.transform.position.y +0.5f);
        }
    }
}
