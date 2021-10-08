using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] GameObject targetPort;
        
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = Vector3.Lerp(other.transform.position, targetPort.transform.position, 1.0f);
    }

}
