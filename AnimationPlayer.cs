using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    // アニメーションクリップを格納する変数
    public AnimationClip idleAnimationClip; // 待機モーション
    public AnimationClip jumpAnimationClip; // ジャンプモーション
    public AnimationClip runAnimationClip; // 走るモーション

    // アニメーションコンポーネントを格納する変数
    private Animation animationComponent;

    // 現在再生中のアニメーション名を管理する変数
    private string currentAnimation = "";
    // ジャンプ状態を管理する変数
    private bool isJumping = false;

    // CharactorMoveスクリプトを格納する変数
    private CharactorMove charactorMove;

    // Start is called before the first frame update
    void Start()
    {
        // Animationコンポーネントを取得
        animationComponent = GetComponent<Animation>();
        // Animationコンポーネントをチェック
        if(animationComponent == null)
        {
            // 新しくAnimationコンポーネントを作成
            animationComponent = 
            gameObject.AddComponent<Animation>();
            Debug.Log("Animationコンポーネントを追加");
        }
        // 待機モーションを登録
        animationComponent.AddClip(idleAnimationClip, "Idle");
        // ジャンプモーションを登録
        animationComponent.AddClip(jumpAnimationClip, "Jump");
        // 走るモーションを登録
        animationComponent.AddClip(runAnimationClip, "Run");

        // CharactorMoveコンポーネントを取得
        charactorMove = GetComponent<CharactorMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプキーが押された場合かつジャンプしていない場合
        // if(Input.GetKeyDown(KeyCode.Space) && !isJumping)
        // {
        //     // ジャンプ状態にする
        //     isJumping = true;
        //     // ジャンプモーションを再生
        //     animationComponent.Play("Jump");
        //     Debug.Log("ジャンプ開始");
        // }
        // // ジャンプが終了した場合
        // if(isJumping && !animationComponent.IsPlaying("Jump"))
        // {
        //     isJumping = false;
        //     Debug.Log("ジャンプ終了");
        //     // 待機モーション再生
        //     animationComponent.Play("Idle");
        // }
        // // ジャンプ中でない場合は別のアニメーションを作成
        // if(!isJumping)
        // {

        //     // WASDキーを押している間は走るアニメーション再生
        //     if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
        //         Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        //     {
        //         // 走るモーション再生
        //         animationComponent.Play("Run");
        //     } else {
        //         // 何もキーが押されていないときには待機モーション再生
        //         animationComponent.Play("Idle");
        //     }
        // }

        // WebGL用
        // Jumpモーションが再生されていないときにアニメーション切り替え
        if(!isJumping){
            if(
                charactorMove != null &&
                charactorMove.IsMoving()
            ){
                // 走るアニメーション再生
                animationComponent.Play("Run");
            } else {
                // 待機アニメーション再生
                animationComponent.Play("Idle");
            }
        }



    }
}