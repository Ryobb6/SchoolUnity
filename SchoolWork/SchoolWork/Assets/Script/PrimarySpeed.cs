using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimarySpeed : MonoBehaviour
{

    [SerializeField] private float acceleration = 1.0f ; // 加速度　月は8.0
    [SerializeField] private Vector3 primaryDirection; //月の初速度としては(-1,0,20)

    // Start is called before the first frame update
    void Start()
    {
        //----------------------------------------------------------------------------
        // Add Force に与える 力 force の計算
        //----------------------------------------------------------------------------
        

        Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();
        float calcMass = rigidbody.mass;
        // F(ベクトル) = ma　だが、Impulseで質量は考慮されるので抜き
        Vector3 primaryForce = primaryDirection * acceleration;

        // F = maに沿って、force を決定最初の瞬間だけ力を加える
        rigidbody.AddForce(primaryForce,ForceMode.Impulse);
    }

   
}
