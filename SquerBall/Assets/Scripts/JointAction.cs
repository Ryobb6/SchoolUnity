using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Joint内にオブジェクトが侵入した際の動作を決めるためのクラスです
/// </summary>
public class JointAction : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
       // 当たったオブジェクト(SpaceShipの速度を0にする)      
        other.GetComponent<SpaceShipController>().Speed= 0f;
    }

    private void OnTriggerExit(Collider other)
    {
        if(this.gameObject.tag == "OutPortCenter")
        {
            other.GetComponent<SpaceShipController>().Speed = 300.0f;
        }
        
    }

}
