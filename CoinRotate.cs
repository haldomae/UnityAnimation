using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    // コインの回転速度
    public float rotateSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // X軸を中心に回転させる
        transform.Rotate(
            // X
            rotateSpeed * Time.deltaTime,
            // Y
            0,
            // Z
            0
        );
    }
}
