using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30; // デフォルトのキャンディの数 : 定数で定める(変更不可)
    const int RecoverySeconds = 10; // Recoveryの秒数


    // 現在のキャンディのストック数
    public int candy = DefaultCandyAmount;
    // ストック回復までの残り秒数
    private int counter;

    public void ConsumeCandy()
    {
        if (candy > 0) candy--; 
    }

    public int GetCandyAmount()
    {
        return this.candy;
    }

    public void AddCandy(int amount)
    {
        this.candy += amount;
    }

    private void OnGUI()
    {
        GUI.color = Color.black;

        string label = "Candy : " + candy;
        // 回復カウントしている時だけ秒数を表示
        if (counter > 0) label = label + "(" + counter + "s)"; // 回復カウントの表示

        // キャンディのストック数を表示
        
        GUI.Label(new Rect(50, 50, 100, 30), label);

    }


    private void Update()
    {
        // キャンディのストックがデフォルトより少なく、
        // 回復カウントをしていないときにカウントをスタートさせる
        if(candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy()); // この関数の処理が始まる
        }

    }

    private IEnumerator RecoverCandy() // yield return の戻り値
    {
        this.counter = RecoverySeconds;

        // 1秒ずつカウントを進める
        while(counter > 0)
        {
            yield return new WaitForSeconds(1.0f);　// 1秒待って、呼び出し元に変えす　
            counter--;
        }

        //WaitForSeconds クラスは YieldInstruction を継承しているため、コルーチンの要素として返すことで指定時間だけコルーチンの実行を待機できます。
        //待機時間は、コンストラクタから指定します。




        candy++;
    }

}
