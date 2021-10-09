using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceRunTitleController : MonoBehaviour
{
    public Text highScoreText;
    public Text beforerecord;

    public void Start()
    {
        //　ハイスコアを表示
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("HighScore") + "m";
        // 実験
       beforerecord.text = "Before Record : " + PlayerPrefs.GetInt("BeforeRecord") + "m";
    }

    public void OnStartButtonClicked()
    {
        // メインのゲームシーンへ移動
        SceneManager.LoadScene("Main");
    }
}
