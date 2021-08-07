using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycastController : MonoBehaviour
{
    Ray ray;        //レイ
    RaycastHit hit; //ヒットしたオブジェクト情報

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transformの取得
        Transform transform = this.transform;
        //座標の取得
        Vector3 pos = transform.position;
        //y軸にずらす
        pos.y = pos.y - 1;

        RaycastHit2D hit = Physics2D.Raycast(pos, new Vector3(0, -1, 0), 100);

        // 可視化
        Debug.DrawRay(pos, new Vector3(0, -1, 0), Color.blue, 1);

        // コンソールにhitしたGameObjectを出力
        Debug.Log(hit.collider);

    }

    void FixedUpdate()
    {
       
    }
}
