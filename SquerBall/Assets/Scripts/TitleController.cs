using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
   public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SelectGame");
    }

   public void OnEndressRunClicked()
    {
        SceneManager.LoadScene("EndressRun");
    }

   public void OnEntranceJupiterClicked()
    {
        SceneManager.LoadScene("JupitarRun");
    }

   public void OnEntranceEarthClicked()
    {
        SceneManager.LoadScene("Earth");
    }
    /// <summary>
    /// 終了ボタン
    /// </summary>
    public void OnExitButtonClicked() 
    {
        Application.Quit();
    }
    public void OnBackToTitleButtonClicked()
    {
        SceneManager.LoadScene("GameTitle");
    }

    public void OnbackToGameSelectButton()
    {
        SceneManager.LoadScene("SelectGame");
    }
    
}
