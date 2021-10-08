using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTarget : MonoBehaviour
{
    [SerializeField]GameObject targetObject;
    Transform targetTransform;
    // Start is called before the first frame update
    void Start()
    {
        targetTransform = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(targetTransform);
    }
}
