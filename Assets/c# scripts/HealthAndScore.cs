using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthAndScore : MonoBehaviour
{
    [SerializeField] private GameObject[] starsHealth;
    public Text objectScore;
    int healthPoint;
    public int score { get; private set; }
    private BallControlCoinMode ballControlCoinMode;

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "spike":
            case "up-down":
                DestroyStar();
                break;
            case "wall":
                score++;
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "hole":
                DestroyStar();
                break;
            case "coin":
                objectScore.text = ballControlCoinMode.coins.ToString();
                break;
            default:
                break;
        }
    }
    private void DestroyStar()
    {
        Destroy(starsHealth[starsHealth.Length - healthPoint]);
        healthPoint--;
        if (healthPoint == 0) GameObject.Find("WetBall").GetComponent<DeathView>().dead = true;
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "mode_spikes")
        objectScore.text = score.ToString();
    }
    private void Start()
    {
        score = 0;
        if (SceneManager.GetActiveScene().name == "mode_spikes")
            healthPoint = 3;
        else if (SceneManager.GetActiveScene().name == "mode_coins")
            healthPoint = 5;
        ballControlCoinMode = GameObject.Find("WetBall").GetComponent<BallControlCoinMode>();
    }
}
