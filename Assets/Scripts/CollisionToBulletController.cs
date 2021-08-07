using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionToBulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("何かと当たりました。");
        if (other.collider.tag == "bullet2")
        {
            //Debug.Log("bulletと当たりました。");
            Destroy(other.gameObject);
        }
        else if (other.collider.tag == "bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
