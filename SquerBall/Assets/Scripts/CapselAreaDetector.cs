using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エリアに入った物体に対して、動作をつけるスクリプトです
/// </summary>
public class CapselAreaDetector : MonoBehaviour
{
    [SerializeField] private bool isHolding; //UI変更用
    [SerializeField] private float decSpeedRate; // コライダに入った時の減速率
    [SerializeField] private float speedToDest = 0; // 目的地へ向かう速度
    [SerializeField] GameObject destinationObject; // 目的地の座標を持つオブジェクト

    private Vector3 destinatonPos; // コライダに入った時に向かうべき方向

    private void Start()
    {
        this.destinatonPos = destinationObject.transform.position; // transformのPositionにて目的情報をセット
        isHolding = false;
    }

    

    /// <summary>
    /// 現在のHolding状況を返します
    /// </summary>
    public bool IsHolding
    {
        get
        {
            return this.isHolding;
        }
        set
        {
            this.isHolding = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isHolding = true;
    }

    private void OnTriggerStay(Collider other)
    {
        // コライダーに宇宙船が触れたら、rigidbodyを取得
        Rigidbody otherrgd = other.gameObject.GetComponent<Rigidbody>();
        Vector3 direction = other.gameObject.transform.position - destinatonPos;
        direction.Normalize();

        // 減速率にしたがって、速度を減速します
        otherrgd.velocity *= decSpeedRate;
        // 目的地に向かって、力を加えます
        otherrgd.AddForce(direction * -1.0f * speedToDest, ForceMode.Acceleration);


        // isHoldingがfalseとなった場合、速度0
        if (!isHolding)
        {
            Rigidbody rd = other.GetComponent<Rigidbody>();
            rd.velocity = Vector3.one;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        isHolding = false;
    }
   
}
