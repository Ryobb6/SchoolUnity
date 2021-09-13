using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Inspector からいじれるようにpublic

    public GameObject[] candyPrefabs;
    public Transform candyParentTransform;
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;

   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
        }
    }

    GameObject SampleCandy()
    {
        int index = Random.Range(0, candyPrefabs.Length); // RandomクラスのRange
        return candyPrefabs[index];
    }

    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        // キャンディを生成できる条件ならShotしない
        if (candyManager.GetCandyAmount() <= 0) return;
        // PrefabからCandy Objectを生成　Gameオブジェクトはnewできない
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            //transform.position,
            Quaternion.identity // Quaternionは回転を表現する構造体(.identityプロパティをGetすると、回転無し)
            );

        // 生成したCandyオブジェクトの親をcandyParentTransformに設定
        candy.transform.parent = candyParentTransform;
        
        // Candy オブジェクトのRigidbodyを取得し力と回転を加える
        // 取得したいクラス型 インスタンス = GameObject型のインスタンス.GetComponent<取得したいクラス型>();
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce); // forwardプロパティは、
        //　そのオブジェクトが向いている方向(z軸のプラス方向)を取得できる
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

        // Shotされた場合、Candyのストックを消費
        candyManager.ConsumeCandy();

    }
}
