using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    // コインのプレハブ
    public GameObject coinPrefab;

    // 生成する範囲
    public float spawnRangeX = 10f;
    public float spawnRangeZ = 10f;

    // 生成する個数
    public int coinCount = 10;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCoin()
    {
        // コインを指定した個数生成
        for(int i = 0; i < coinCount; i++)
        {
            // ランダム位置を計算
            float randomX = Random.Range(
                -spawnRangeX, spawnRangeX
            );
            float randomZ = Random.Range(
                -spawnRangeZ, spawnRangeZ
            );

            // 生成位置
            Vector3 spawnPosition = new Vector3(
                randomX,
                0.5f,
                randomZ
            );

            // コイン生成
            Instantiate(
                // コインのプレハブ
                coinPrefab,
                // 生成位置
                spawnPosition,
                // 回転(回転なし)
                Quaternion.identity
            );
        }
    }

    // コインリセット
    public void RespawnCoins()
    {
        // 既に置かれているコインを全て削除
        foreach(GameObject coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            Destroy(coin);
        }
        // 新しいコインを生成
        SpawnCoin();
    }
}
