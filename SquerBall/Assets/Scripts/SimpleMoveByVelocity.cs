using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveByVelocity : MonoBehaviour
{
    [SerializeField]private float velocityX;
    private Vector3 vector;
    private Vector3 force;
    private Rigidbody rg;
    void Start()
    {
        this.vector = new Vector3(this.velocityX,0, 0);
        this.rg = GetComponent<Rigidbody>();
        this.force = this.vector;
    }

    // Update is called once per frame
    void Update()
    {
         //  * Time.fixedDeltaTime*10
        this.rg.AddForce(this.force, ForceMode.VelocityChange);
    }
}
