using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //Rigidbody2Dを宣言
    Rigidbody2D rigid2D;
    //弾のスピード
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        //弾のスピードの初期化
        this.speed = 3.0f;
        //アタッチされている、Rigidbody2Dを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //弾へ力を加える（弾の発射処理）
        rigid2D.velocity = new Vector2(0,this.speed);
    }
}
