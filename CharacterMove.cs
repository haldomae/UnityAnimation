using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    // 移動速度(Unityの開発画面からいつでも速度が変更できる)
    public float moveSpeed = 5f;
    // 回転速度
    public float rotationSpeed = 720f;


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

        // 移動方向がある場合のみ処理
        if(moveDirection.magnitude > 0.1f){
            // 移動方向を正規化(長さを1にする)
            moveDirection.Normalize();
            // 座標移動
            transform.position += 
            moveDirection * moveSpeed * Time.deltaTime;

            // 移動方向への回転を計算
            Quaternion targetRotation = 
            Quaternion.LookRotation(moveDirection);

            // 滑らかに回転させる
            transform.rotation = 
            Quaternion.RotateTowards(
                // 現在の回転
                transform.rotation,
                // 目標の回転
                targetRotation,
                // 回転速度
                rotationSpeed * Time.deltaTime
            );
        }
    }
}
