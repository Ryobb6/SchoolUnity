using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveByVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 initialSpeed;
    [SerializeField] private float speedScale = 1.0f;
    [SerializeField] private bool initialSpeedApply = true;
    private Vector3 force;
    private Vector3 pulsForce;
    private Rigidbody rg;
    void Start()
    {
        this.force = initialSpeed;
        this.rg = GetComponent<Rigidbody>();
        if (initialSpeedApply)
        {
            this.rg.AddForce(this.force, ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void Update()
    {
        pulsForce.x = Input.GetAxis("Horizontal");
        pulsForce.z = Input.GetAxis("Vertical");

        if (Input.GetKey("z"))
        {
            pulsForce.y = 1.0f;
        }

        if (Input.GetKey("space"))
        {
            pulsForce.y = -1.0f;
        }

        this.pulsForce = speedScale * pulsForce.normalized;
         //  * Time.fixedDeltaTime*10
        this.rg.AddForce(this.pulsForce, ForceMode.Force);
    }
}
