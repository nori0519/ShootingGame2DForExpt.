using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBullet2Script : MonoBehaviour
{
    //弾のスピード
    public float speed_b2;

    //Rigidbody2Dを宣言する
    Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rigid2D.velocity = new Vector2(0, -speed_b2);
    }
}
