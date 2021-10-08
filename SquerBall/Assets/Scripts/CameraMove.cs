using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float followSpeed;
    private Vector3 diff;
  
    void Start()
    {
        diff = target.transform.position - this.transform.position;
    }

   
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position - diff, Time.deltaTime * followSpeed);
    }
}
