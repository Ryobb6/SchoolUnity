using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30; // 定数で定める(変更不可)
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
        // 回復カウントをしていないときにカウントをすたーとさせる
        if(candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy());
        }

    }

    private IEnumerator RecoverCandy()
    {
        this.counter = RecoverySeconds;

        // 1秒ずつカウントを進める
        while(counter > 0)
        {
            yield return new WaitForSeconds(1.0f);
            counter--;
        }

        candy++;
    }

}
