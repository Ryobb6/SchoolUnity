using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 自転用
/// </summary>
public class SelfRotation : MonoBehaviour
{
  
    // Start is called before the first frame update
    // 中心点
    [SerializeField] private Vector3 starCenter = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 starAxis = Vector3.up;

    // 円運動周期
    [SerializeField] private float starSelfRotPeriod = 25;

    private void Update()
    {
        // 中心点の周りを、軸axisで、starSelfRotPeriod周期で円運動
        transform.RotateAround(starCenter, starAxis, 360 / starSelfRotPeriod * Time.deltaTime);
    }
}
