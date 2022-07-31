using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestscoreDetails;
    public TextMeshProUGUI getName;

    private void Start()
    {
        if (MainManager.Instance.loadScore != 0)
        {
            UpdateBestScore();
        }
    }

    public void StartNew()
    {
        MainManager.Instance.Name = getName.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        if (Application.isEditor)
        {
            EditorApplication.ExitPlaymode();
        }
        else
        {
            Application.Quit(); // original code to quit Unity player
        }

    }

    public void ResetBestScore()
    {
        MainManager.Instance.Name = "Name";
        MainManager.Instance.Score = 0;
        MainManager.Instance.SaveBestScore();
        MainManager.Instance.LoadBestScore();
    }

    public void UpdateBestScore()
    {
        bestscoreDetails.text = "Best Score : " + MainManager.Instance.loadName + " : " + MainManager.Instance.loadScore;
    }
}
