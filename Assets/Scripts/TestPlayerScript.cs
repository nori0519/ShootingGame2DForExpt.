using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
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
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");

        rigid2D.velocity = new Vector2(hori, vert) * 5;
    }
}
