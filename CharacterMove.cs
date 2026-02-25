using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    // 移動速度(Unityの開発画面からいつでも速度が変更できる)
    public float moveSpeed = 5f;
    // 回転速度
    public float rotationSpeed = 720f;

    // WebGL用
    // 目的地点に到達したとみなす距離
    public float stopDistance = 0.3f;
    // カメラの目線
    private Camera mainCamera;
    // 目的地点
    private Vector3 targetPosition;
    // 移動中かどうか
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        // カメラを取得
        mainCamera = Camera.main;
        // 初期の目的地点(自分の座標)
        // Unityちゃんの最初の位置
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // // キー入力値
        // float horizontal = Input.GetAxis("Horizontal"); // A,D
        // float vertical = Input.GetAxis("Vertical"); // W,S

        // // 移動方向を計算
        // Vector3 moveDirection = 
        // new Vector3(horizontal, 0 , vertical);

        // // 移動方向がある場合のみ処理
        // if(moveDirection.magnitude > 0.1f){
        //     // 移動方向を正規化(長さを1にする)
        //     moveDirection.Normalize();
        //     // 座標移動
        //     transform.position += 
        //     moveDirection * moveSpeed * Time.deltaTime;

        //     // 移動方向への回転を計算
        //     Quaternion targetRotation = 
        //     Quaternion.LookRotation(moveDirection);

        //     // 滑らかに回転させる
        //     transform.rotation = 
        //     Quaternion.RotateTowards(
        //         // 現在の回転
        //         transform.rotation,
        //         // 目標の回転
        //         targetRotation,
        //         // 回転速度
        //         rotationSpeed * Time.deltaTime
        //     );
        // }

        // WebGL用
        // タップ、クリック入力の取得
        bool inputDetected = false;
        // 2次元座標から取得
        Vector2 inputScreenPosition = Vector2.zero;

        // スマートフォン：タッチ入力
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            // タッチし始めた最初のフレームのみ目的地点を更新
            if(touch.phase == TouchPhase.Began){
                inputDetected = true;
                inputScreenPosition = touch.position;
            }
        }
        // デバック用
        // マウス入力
        else if(Input.GetMouseButtonDown(0))
        {
            inputDetected = true;
            inputScreenPosition = Input.mousePosition;
        }

        // タップした位置を3D空間に変換
        if(inputDetected)
        {
            // スクリーン座標をレイに変換
            Ray ray = mainCamera.ScreenPointToRay(inputScreenPosition);
            RaycastHit hit;

            // Rayが地面に当たった場合、その位置を目的地点に設定
            if(Physics.Raycast(ray, out hit)){
                targetPosition = new Vector3(
                    // X
                    hit.point.x,
                    // Y
                    transform.position.y,
                    // Z
                    hit.point.z
                );
                isMoving = true;
            }
        }

        // 目的地点に移動
        if(isMoving)
        {
            // 目的地点との距離を計算
            float distance = Vector3.Distance(
                // 現在の位置
                transform.position,
                // 目的地点
                targetPosition
            );

            // 目的地点に十分に近づいたら停止
            if(distance < stopDistance)
            {
                isMoving = false;
                return;
            }

            // 移動方向を計算
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            // 座標移動
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

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

    // AnimationPlayerから移動中かどうかを取得するための関数
    public bool IsMoving()
    {
        return isMoving;
    }
}
