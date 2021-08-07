using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer2Script : MonoBehaviour
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
       
    }

    private void FixedUpdate()
    {
        var x = Random.Range(-0.25f,0.25f);
        var y = Random.Range(0,0);

        rigid2D.velocity = new Vector2(x,y) * 5;
    }
}
