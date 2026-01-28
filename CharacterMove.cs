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
        // Wキーが押された間、前方に移動
        if(Input.GetKey(KeyCode.W)){
            // transformのz軸を更新
            // GetComponent<Transform>()は省略可能
            // Vector3.forward = new Vector3(0,0,1)
            // Time.deltaTimeフレームレートの影響受けなくなる
            transform.position += 
            Vector3.forward * moveSpeed * Time.deltaTime;
        }
        // Sキーが押された間、後方に移動
        if(Input.GetKey(KeyCode.S)){
            // Vector3.back = new Vector3(0,0,-1)
            transform.position += 
            Vector3.back * moveSpeed * Time.deltaTime;
        }

        // Aキーが押された間、左方向に移動
        if(Input.GetKey(KeyCode.A)){
            // Vector3.left = new Vector3(-1,0,0)
            transform.position += 
            Vector3.left * moveSpeed * Time.deltaTime;
        }

        // Dキーが押された間、右方向に移動
        if(Input.GetKey(KeyCode.D)){
            // Vector3.right = new Vector3(1,0,0)
            transform.position += 
            Vector3.right * moveSpeed * Time.deltaTime;
        }
    }
}
