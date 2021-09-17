using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGraviation : MonoBehaviour
{
    public GameObject starOne;
    public GameObject starTwo;
    public float gravityConstruct = 1.0f;
    // 引力を与えるスクリプト
    // 重力波影響範囲は、コライダーで仮に再現
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rigidbody = other.gameObject.GetComponent<Rigidbody>();

        Vector3 direction = other.gameObject.transform.position - this.transform.position;

        // 1と2(地球と月)の距離の2乗の長さ / 1,000,000
        Vector3 rbyr = new Vector3(direction.x * direction.x, direction.y * direction.y, direction.z * direction.z);
        float distanceOfStar = rbyr.magnitude / 1000000; 
        // 地球と月の質量
        float earthMass = starOne.GetComponent<Rigidbody>().mass;
        float moonMass = starTwo.GetComponent<Rigidbody>().mass;
        
        float gravityForce = this.gravityConstruct * (earthMass * moonMass) / distanceOfStar;
        Debug.Log(gameObject.name + "質量  x 質量 : " + earthMass * moonMass + " 距離 x 距離 / 1000000:  " + distanceOfStar + "重力 : " + gravityForce);
        

        direction.Normalize();
        rigidbody.AddForce(direction * -2.0f, ForceMode.VelocityChange);


    }
}
