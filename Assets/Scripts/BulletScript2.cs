using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript2 : MonoBehaviour
{
    //弾のスピード
    static public float speed_b2;
    //Rigidbody2Dを宣言する
    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        //アタッチされている、Rigidbody2Dを取得
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //弾へ力を加える（弾の発射処理）
    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(0, speed_b2);
    }
}
