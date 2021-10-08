using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //カメラを格納する変数
    [SerializeField]private Camera Camera;
    [SerializeField] private Camera subCamera;
   
    void Start()
    {
        subCamera.enabled = false;
    }
        
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && !subCamera.enabled)
        {
            subCamera.enabled = true;
            Camera.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.C) && subCamera.enabled)
        {
            subCamera.enabled = false;
            Camera.enabled = true;
        }
        
    }

    //ボタンを押した時の処理
    public void PushCameraButton()
    {
        //もしサブカメラがオフだったらサブカメラをオンにしてメインカメラをオフ
        if (!subCamera.enabled)
        {
            subCamera.enabled = true;
            Camera.enabled = false;
        }
        //もしサブカメラがオンだったら サブカメラをオフにしてメインカメラをオン
        else
        {
            subCamera.enabled = false;
            Camera.enabled = true;
        }
    }
}
