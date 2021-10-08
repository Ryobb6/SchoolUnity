using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControllByTarget : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 targetPos;
    void Start()
    {
        targetPos = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
