using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpaceShipController : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform tr;

    public float Speed { get => speed; set => speed = value; }

    private void Awake()
    {
        this.tr = this.gameObject.transform;
    }

     void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AxleForward();     
        }
    }

    private float GetSelfForwardAxis()
    {
        return 1.0f;
    }

    private void AxleForward()
    {
       
    }

}
