using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathView : MonoBehaviour
{
    public Text objectBestScore;
    [SerializeField] private GameObject ball;
    public bool dead=false;
    void Update()
    {
        if (dead)
        {
            StopGame();
            if (SceneManager.GetActiveScene().name == "mode_spikes")
                DeathSpikeMode();
            else
                DeathCoinMode();
        }
    }
    private void SaveRecord()
    {
        if (SceneManager.GetActiveScene().name == "mode_spikes")
        {
            int score = GameObject.Find("WetBall").GetComponent<HealthAndScore>().score;
            GameObject.Find("TableScoreManager").GetComponent<BestScoreTableCounter>().GetNewRecord(User.UserName, score);
        }
    }
    private void StopGame()
    {
        PauseMenu.AbleToPause = false;
        Destroy(ball);
        SaveRecord();
    }
    private void PrintBestScore()
    {
        objectBestScore.text = LoadAndSave.Load(User.UserName+"score").ToString();
    }
    private void CompareBestAndLastScore()
    {
        int score = GameObject.Find("WetBall").GetComponent<HealthAndScore>().score;
        int bestScore = PlayerPrefs.GetInt(User.UserName + "score");
        if (score>bestScore)
        {
            PlayerPrefs.SetInt(User.UserName + "score", score);
                PlayerPrefs.Save();
        }
        
    }
    private void DeathSpikeMode()
    {
        CompareBestAndLastScore();
        PrintBestScore();
    }
    private void ShowSweetsEnd()
    {
        //Реализовано в класса BallControlCoinMode
    }
    private void DeathCoinMode() 
    {
        ShowSweetsEnd();
        int coins = GameObject.Find("WetBall").GetComponent<BallControlCoinMode>().coins;
        objectBestScore.text = coins.ToString();
        PlayerPrefs.SetInt(User.UserName + "coins", PlayerPrefs.GetInt(User.UserName + "coins")+coins);
    }
}
