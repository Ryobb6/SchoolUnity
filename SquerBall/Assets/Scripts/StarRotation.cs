using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarRotation : MonoBehaviour
{
    // Start is called before the first frame update
    // 中心点
    [SerializeField] private Vector3 starCenter = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 starAxis = Vector3.up;

    // 円運動周期
    [SerializeField] private float starSelfRotPeriod = 24;

    private void Update()
    {
        // 中心点centerの周りを、軸axisで、period周期で円運動
        transform.RotateAround(starCenter, starAxis, 360 / starSelfRotPeriod * Time.deltaTime);
    }
}
