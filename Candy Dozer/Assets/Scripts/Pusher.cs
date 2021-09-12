using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;
   
    public float amplitude; // 移動量field Inspectorから調整できるようにpublic
    public float speed; // 移動速度field Inspectorから調整できるようにpublic

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition; // AttacheしたゲームオブジェクトのtrasformプロパティのlocalPositionを取得
        // (プロパティ transformにてtransformクラスのインスタンスを取得
        // さらに、transformインスタンスがもつlocalPositionプロパティにて、Vector3構造体のインスタンスを取得)
    }

    // Update is called once per frame
    void Update()
    {
        // 変位を計算
        float z = amplitude * Mathf.Sin(Time.time * speed); // 移動量の計算
        // Time.timeはゲームがスタートしてからの秒数をfloat値で取得できます
        // それをSin関数に渡す事で波形型の値を取得します。


        // zを変位させたポジションに再設定
        transform.localPosition = startPosition + new Vector3(0, 0, z);
    }
}
