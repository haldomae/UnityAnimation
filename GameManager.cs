using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // シングルトン(どこからでもアクセスできる)
    public static GameManager Instance;

    // 現在のスコア
    private int score = 0;

    // CoinSpawnerを使えるようにしておく
    public CoinSpawner coinSpawner;

    // シングルトンの初期化
    void Awake()
    {
        // インスタンスを設定
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // スコアを加算するメソッド
    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("スコア : " + score);
    }

    // スコアを取得するメソッド
    public int GetScore()
    {
        return score;
    }

    // ゲームをリセットするメソッド
    public void RespawnCoins()
    {
        // スコアリセット
        score = 0;

        // コインを再生成
        if(coinSpawner != null)
        {
            coinSpawner.RespawnCoins();
        }
    }
}
