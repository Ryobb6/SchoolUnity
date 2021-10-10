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
        SceneManager.LoadScene("Jupitar");
    }

   public void OnEntranceEarthClicked()
    {
        SceneManager.LoadScene("Earth");
    }
}
