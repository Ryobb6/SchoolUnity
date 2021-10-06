using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エリアに入った物体に対して、動作をつけるスクリプトです
/// </summary>
public class CapselAreaDetector : MonoBehaviour
{
    [SerializeField] private bool isHolding; //UI変更用
    // Start is called before the first frame update
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
        Rigidbody rg = other.gameObject.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        isHolding = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
