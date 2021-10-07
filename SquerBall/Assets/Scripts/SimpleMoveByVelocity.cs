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
        // GameObjectタグによって、回転の挙動を分けます
        // tagがないときは、回転させません

        // 水平方向
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.tag == "SpaceShip")
            {
                float valueX = Input.GetAxis("Horizontal");
                pulsForce.x = valueX;
                this.rg.AddTorque(new Vector3(0, torqueSpeed * valueX, 0));
            }
            else
            {
                pulsForce.x = Input.GetAxis("Horizontal");
            }
        }

        //前後方向
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (gameObject.tag == "SpaceShip")
            {
                float valueY = Input.GetAxis("Vertical");
                pulsForce.x = valueY;
                this.rg.AddTorque(new Vector3(0, 0, torqueSpeed * valueY));
            }
            else
            {
                pulsForce.x = Input.GetAxis("Vertical");
            }
        }


        if (Input.GetKey("z"))
        {
            pulsForce.y = 1.0f;
            if(gameObject.tag == "SpaceShip")
            {
                this.rg.AddTorque(new Vector3(torqueSpeed * 1.0f, 0, 0));
            }
        }

        if (Input.GetKey("space"))
        {
            pulsForce.y = -1.0f;
            if (gameObject.tag == "SpaceShip")
            {
                this.rg.AddTorque(new Vector3(torqueSpeed * -1.0f, 0, 0));
            }
        }

        this.pulsForce = speedScale * pulsForce.normalized;
        this.rg.AddForce(this.pulsForce, ForceMode.Force);
    }
}
