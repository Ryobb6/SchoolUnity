using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour
{
    // レーンの導入
    private const int MinLane = -2;
    private const int MaxLane = 2;
    private const float LaneWidth = 1.0f;
    // ライフ設定
    private const int DefalutLife = 3;
    // コルーチン用
    private const float StunDuration = 0.5f;

    private Rigidbody controller;
    private Animator animator;

    private Vector3 moveDirection = Vector3.zero;
    private int targetLane;
    private int life = DefalutLife;
    private float recoverTime = 1.0f;

    // Insperctorから設定
    public float gravity; // 重力
    public float speedZ; // Z軸方向へのSpeed
    public float speedX; // 横方向スピードのパラメータ
    public float speedJump; // JampのSpeed
    public float accelerationZ; //前進の加速度

    public int Life
    {
        get
        {
            return this.life;
        }
    }

    /// <summary>
    /// 気絶判定
    /// </summary>
    /// <returns></returns>
    private bool IsStun()
    {

        bool stun = this.recoverTime > 0.0f || this.life <= 0;
        return stun;
    }

    // Start is called before the first frame update
    void Start()
    {
        // アタッチされたコンポーネントの取得　
        //this.controller = GetComponent<CharacterController>(); 
        //this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用キーの入力(KeyDownは押された瞬間)
        if (Input.GetKeyDown("left"))
        {
            MoveToLeft();
        }
        if (Input.GetKeyDown("right"))
        {
            MoveToRight();
        }
        if (Input.GetKeyDown("space"))
        {
            Jump();
        }

        if (IsStun())
        {
            // 動きを止め、気絶状態からの復帰カウントを進める
            this.moveDirection.x = 0.0f;
            this.moveDirection.z = 0.0f;
            this.recoverTime -= Time.deltaTime;

        }
        else
        {
            // 徐々に加速してZ方向に常に前進させる
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            // X方向は目標のポジションまでの差分の割合で速度を計算
            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;
        }

        this.moveDirection.y -= this.gravity * Time.deltaTime;   // Time.deltaTimeでは、全フレームからの経過時間を取得できる
        // 異なるFPSでも一定の割合の値をyにマイナスする


        //移動実行
        Vector3 globalDirection = transform.TransformDirection(this.moveDirection);
        this.controller.AddForce(globalDirection * Time.deltaTime);

       
    }


    // 左のレーンに移動
    public void MoveToLeft()
    {
        if (IsStun()) // 気絶時は、移動しないようにする
        {
            return;
        }

        if(targetLane > MinLane)
        {
            targetLane--;
        }
    }

    // 右のレーンに移動を開始
    public void MoveToRight()
    {
        if (IsStun()) // 気絶時は、移動しないようにする
        {
            return;
        }

        if (targetLane < MaxLane)
        {
            targetLane++;
        }
    }

    public void Jump()
    {
        if (IsStun()) // 気絶時は、移動しないようにする
        {
            return;
        }

           moveDirection.y = speedJump;
        
        }
    }

    // CharacterControllerに衝突判定が生じたときの処理
 
    




