using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DockingController : MonoBehaviour
{
    [SerializeField] private bool isHolding; //UI変更用
    
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
        Vector3 direction = other.gameObject.transform.position - this.transform.position;
        direction.Normalize();

        // 減速
        otherrgd.velocity *= 0.5f;

        otherrgd.AddForce(direction * -20.0f, ForceMode.Acceleration);


    }

    private void OnTriggerExit(Collider other)
    {
        isHolding = false;
    }
}

