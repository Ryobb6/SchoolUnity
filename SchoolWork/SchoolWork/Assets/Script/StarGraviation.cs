using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGraviation : MonoBehaviour
{
    public GameObject starOne;
    public GameObject starTwo;
    // 引力を与えるスクリプト
    // 重力波影響範囲は、コライダーで仮に再現
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = other.gameObject.transform.position - this.transform.position;

        // 地球と月の距離の2乗
        Vector3 rbyr = new Vector3(direction.x * direction.x, direction.y * direction.y, direction.z * direction.z);
        // 地球と月の質量
        float earthMass = starOne.GetComponent<Rigidbody>().mass;
        float moonMass = starTwo.GetComponent<Rigidbody>().mass;
        Debug.Log(earthMass * moonMass + " :  " + rbyr);

        direction.Normalize();
        rigidbody.AddForce(direction * -2.0f, ForceMode.VelocityChange);


    }
}
