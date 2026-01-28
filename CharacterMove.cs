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

    }
}
