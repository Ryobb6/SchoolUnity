using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public NejikoController nejiko;
    public Text scoreText;
    public Text beforeRecord;
    public LifePanel lifePanel;

    // Update is called once per frame
    void Update()
    {
        // スコアを更新
        int score = CalcScore();
        int record = PlayerPrefs.GetInt("BeforeRecord");
        this.scoreText.text = "Score : " + score + "m";
        this.beforeRecord.text = "BeforeRecord : " + record+ "m";

        // ライスパネルを更新 Nejikoに設定したLifeプロパティを参照
        lifePanel.UpdateLife(nejiko.Life);

        if(nejiko.Life <= 0)
        {
            // これ以上のUpdateはやめる
            enabled = false;

            // ハイスコアを更新
            if(PlayerPrefs.GetInt("HighScore") < score) 
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            
            //今回のレコードを更新
                PlayerPrefs.SetInt("BeforeRecord", score);
            


            // 2秒後にReturnToTitleを呼び出す
            Invoke("ReturnToTitle", 2.0f);

        }
        
    }

    private int CalcScore()
    {
        //ねじ子の走行距離をスコアとする
        return (int)nejiko.transform.position.z;
    }

    private void ReturnToTitle()
    {
        //タイトルシーンに切り替え
        SceneManager.LoadScene("Title");

    }


}
