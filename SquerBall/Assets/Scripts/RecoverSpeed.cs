using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoverSpeed : MonoBehaviour
{
    public GameObject targetObject;
    public float applySpeed;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        targetObject.GetComponent<SpaceShipController>().Speed = this.applySpeed;
    }
}
