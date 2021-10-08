using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveByVelocity : MonoBehaviour
{
    [SerializeField] private Vector3 initialSpeed;
    [SerializeField] private float speedScale = 1.0f;
    [SerializeField] private bool initialSpeedApply = true;
    [SerializeField] private float torqueSpeed=1.0f;

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

    
    void Update()
    {
        
        // 水平方向
        if(Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown(KeyCode.LeftArrow))
        {
            HorizontalMove(Input.GetAxis("Horizontal"));
           
        }

        //前後方向
        if (Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown(KeyCode.DownArrow))
        {
            VerticalMove(Input.GetAxis("Vertical"));
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            UpMove();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DownMove();
        }

        
    }

    public void HorizontalMove(float x)
    {
        // 水平方向
        Vector3 vector = new Vector3(x, 0, 0);
        ForceExecute(vector);
    }

    public void VerticalMove(float z)
    {
        Vector3 vector = new Vector3(0, 0, z);
        ForceExecute(vector);
    }

    public void UpMove()
    {
        Vector3 vector = new Vector3(0, 1.0f, 0);
        ForceExecute(vector);
    }

    public void DownMove()
    {
        Vector3 vector = new Vector3(0, -1.0f, 0);
        ForceExecute(vector);
    }

    /// <summary>
    /// 力を加えます
    /// </summary>
    private void ForceExecute(Vector3 vector)
    {
        pulsForce = speedScale * vector.normalized;
        Debug.Log(pulsForce.x + ":" + pulsForce.y + ":" + pulsForce.z);
        rg.AddForce(pulsForce, ForceMode.Force);
    }

}
