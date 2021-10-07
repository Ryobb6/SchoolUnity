﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エリアに入った物体に対して、動作をつけるスクリプトです
/// </summary>
public class CapselAreaDetector : MonoBehaviour
{
    [SerializeField] private bool isHolding; //UI変更用
    // Start is called before the first frame update
    [SerializeField] private Vector3 destinatonPos;
    private void Start()
    {
        isHolding = false;
    }

    public bool IsHolding
    {
        get
        {
            return this.isHolding;
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

        // 減速
        otherrgd.velocity *= 0.9f;

        otherrgd.AddForce(direction * -100.0f, ForceMode.Acceleration);


    }

    private void OnTriggerExit(Collider other)
    {
        isHolding = false;
    }

   
}
