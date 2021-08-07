using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet2GeneratorScript : MonoBehaviour
{
    //弾オブジェクト
    public GameObject bullet2Prefab;
    //プレイヤオブジェクト
    GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        //ヒエラルキーから該当オブジェクト検索
        //プレイヤ２
        this.player2 = GameObject.Find("player2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            //弾を定義
            GameObject bullet2 = Instantiate(bullet2Prefab) as GameObject;
            //弾をプレイヤの中心座標から生成
            bullet2.transform.position = new Vector2(this.player2.transform.position.x + 0.45f, this.player2.transform.position.y - 1);
        } 
    }
}
