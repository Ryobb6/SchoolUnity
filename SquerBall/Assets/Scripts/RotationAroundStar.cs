using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAroundStar : MonoBehaviour
{
    // (理想) 動く太陽のPositionを用意 : (現実)World座標で、(0,0,0)固定
    
    [SerializeField] private Vector3 _center = Vector3.zero;

    // 回転軸
    [SerializeField] private Vector3 _axis = Vector3.up;

    // 円運動周期
    [SerializeField] private float _period = 365;

    // 向きを更新するかどうか
    [SerializeField] private bool _updateRotation = true;

    private void Update()
    {
        //--------------------------------------------------------------
        //<天体の回転について : Quatarnionの利用>
        //--------------------------------------------------------------

        //Quaternion.AngleAxis()は、指定された角度と軸での回転を表すクォータニオンを取得する
        // 引数 1 . Angle(角度 : オイラー角) 引数 2 . Axis(軸)

        // ------軸についてのメモ------
        //Vector3.right（x軸を指定したい場合）
        //Vector3.up（y軸を指定したい場合）→　今回はY軸中心
        //Vector3.forward（z軸を指定したい場合）


        // 回転のクォータニオン作成
        Quaternion angleAxis = Quaternion.AngleAxis(360 / _period * Time.deltaTime, _axis);

        // 円運動の位置計算(Y軸中心)
        Transform tr = transform;
        Vector3 pos = tr.position;

        pos -= _center;
        pos = angleAxis * pos;
        pos += _center;

        tr.position = pos;

        // 向き更新
        if (_updateRotation)
        {
            tr.rotation = tr.rotation * angleAxis;
        }
    }
}
