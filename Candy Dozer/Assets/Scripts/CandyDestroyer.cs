using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyDestroyer : MonoBehaviour
{
    public CandyManager candyManager;
    public int reward; // 生成できるオブジェクトのストック個数
    public GameObject effectPrefab;
    public Vector3 effectRotation;

   private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Candy")
        {
            // 指定数だけCandyのストックを増やす
            candyManager.AddCandy(reward);

            //オブジェクトを削除
            Destroy(other.gameObject);
        }
    }
}
