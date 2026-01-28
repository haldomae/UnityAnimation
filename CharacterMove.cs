using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    // 移動速度(Unityの開発画面からいつでも速度が変更できる)
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // キー入力値
        float horizontal = Input.GetAxis("Horizontal"); // A,D
        float vertical = Input.GetAxis("Vertical"); // W,S

        // 移動方向を計算
        Vector3 moveDirection = 
        new Vector3(horizontal, 0 , vertical);

        // 座標移動
        transform.position += 
        moveDirection * moveSpeed * Time.deltaTime;
    }
}
