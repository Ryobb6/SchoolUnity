using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMoveManager : MonoBehaviour
{
    private Transform _cameraTransform;
    [SerializeField] private Transform _cameraMoveTargetTransform;
    private Vector3 _oldTargetPosition;

    private void Awake()
    {
        _cameraTransform = transform;
        _oldTargetPosition = _cameraMoveTargetTransform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraTargetPosition = _cameraMoveTargetTransform.position;

        if (_oldTargetPosition != cameraTargetPosition)
        {
            Vector3 moveAmount = cameraTargetPosition - _oldTargetPosition;
            _cameraTransform.position += moveAmount;
            _oldTargetPosition = cameraTargetPosition;
        }
    }
}
