using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// JavaScriptと連携する為に必要
using System.Runtime.InteropServices;

public class CoinCollect : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void OnCoinCollected(int score);
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

            // HTML側にスコアを送信
            #if !UNITY_EDITOR
            OnCoinCollected(GameManager.Instance.GetScore());
            #endif

            // コインを削除
            Destroy(gameObject);
        }
    }
}
