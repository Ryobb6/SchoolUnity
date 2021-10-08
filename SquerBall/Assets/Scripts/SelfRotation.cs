using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自転公転両用 
/// 公転の場合は、基軸の空オブジェクトに対して適用
/// </summary>
public class SelfRotation : MonoBehaviour
{

    
    // 中心点
    [SerializeField] private Vector3 starCenter = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 starAxis = Vector3.up;

    // 円運動周期
    [SerializeField] private float starSelfRotPeriod = 25;


    private void Start()
    {
        // CenterPositionに自身のPositionを適用
        starCenter = transform.position;
    }

    private void Update()
    {
        // 中心点の周りを、軸axisで、starSelfRotPeriod周期で円運動
        starCenter = transform.position;
        transform.RotateAround(starCenter, starAxis, 360 / starSelfRotPeriod * Time.deltaTime);
    }
}
