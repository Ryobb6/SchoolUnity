using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;

    int shotPower = MaxShotPower;


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

    /// <summary>
    /// PrefabからGameObjectを生成する場所を決定する
    /// </summary>
    /// <returns></returns>
    Vector3 GetInstantiatePosition()
    {
        float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
        return transform.position + new Vector3(x, 0, 0);
    }

    public void Shot()
    {
        // キャンディを生成できない条件ならShotしない
        if (candyManager.GetCandyAmount() <= 0) return;
        if (shotPower <= 0) return; // ショットパワーのチェック

        // PrefabからCandy Objectを生成　Gameオブジェクトはnewできない
        GameObject candy = (GameObject)Instantiate(
            SampleCandy(),
            GetInstantiatePosition(),
            // transform.position,
            Quaternion.identity // Quaternionは回転を表現する構造体(.identityプロパティをGetすると、回転無し)
            );


        // 生成したCandyオブジェクトの親をcandyParentTransformに設定
        candy.transform.parent = candyParentTransform;
        
        // Candy オブジェクトのRigidbodyを取得し力と回転を加える
        // 取得したいクラス型 インスタンス = GameObject型のインスタンス.GetComponent<取得したいクラス型>();
        Rigidbody candyRigidBody = candy.GetComponent<Rigidbody>();
        candyRigidBody.AddForce(transform.forward * shotForce); // forwardプロパティは、そのオブジェクトが向いている方向(z軸のプラス方向)を取得できる
        // AddTorque RigidBodyに回転を加える
        candyRigidBody.AddTorque(new Vector3(0, shotTorque, 0));

        // Shotされた場合、Candyのストックを消費
        candyManager.ConsumeCandy();

    }

    private void OnGUI()
    {
        GUI.color = Color.black;

        // ShotPowerの残数を+の数で表示
        string label = "";
        for (int i = 0; i < shotPower; i++) label = label + "+";

        GUI.Label(new Rect(50, 65, 100, 30), label);



    }

    private void CustomPower()
    {
        // ShotPowerを消費すると同時に回復のカウントをスタート
        shotPower--;
        StartCoroutine(RecoverPower()); // 引数にCoroutine関数を渡す

    }

    private IEnumerator RecoverPower()
    {
        // 一定秒数待った後にshotPowerを1回復
        yield return new WaitForSeconds(RecoverySeconds);
        shotPower++; 

    }



}
