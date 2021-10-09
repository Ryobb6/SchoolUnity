using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour
{
    private Vector3 diff;

    public GameObject target; // 追従ターゲットフィールド
    public float followSpeed;

   
    void Start()
    {
        this.diff = this.target.transform.position - this.transform.position; // ターゲットとどのくらいの距離を保ちながら追従するか
        // 常に一定距離を保つようにする
    }

    private void LateUpdate()
    {
        //float bfr = (this.target.transform.position.z-this.diff.z) - this.transform.position.z;
        this.transform.position = Vector3.Lerp(this.transform.position, this.target.transform.position - this.diff, 0.5f);
        //float aft = (this.target.transform.position.z - this.diff.z) - this.transform.position.z;
        //Debug.Log(aft/bfr);
       
        // 線形補完によるスムージングです
        // 第一引数と第二引数の間の値で、第三引数を割合(%)としたPositionを得ます

    }
}
