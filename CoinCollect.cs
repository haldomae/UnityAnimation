using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // プレイヤーに当たった場合(Playerのタグが付いている場合)
        if(other.CompareTag("Player"))
        {
            // スコアを加算
            GameManager.Instance.AddScore(1);

            Debug.Log("コインに当たった");

            // コインを削除
            Destroy(gameObject);
        }
    }
}
