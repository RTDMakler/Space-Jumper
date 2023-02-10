using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlCoinMode : MonoBehaviour
{
    [SerializeField] private GameObject bubbles;
    [SerializeField] private Rigidbody2D ball;
    public GameObject DeadMenu;
    public int coins=0;
    public static bool alive;
    private float deathLevelJump = 1;

    private void Awake()
    {
        alive = true;
    }
    public void FixedUpdate()
    {
        if (ball.transform.position.y > 500)
        {
            ball.velocity = new Vector2(ball.velocity.x, -1400 * deathLevelJump);
        }
        else if (ball.transform.position.y < -620)
        {
            ball.velocity = new Vector2(ball.velocity.x, 1400* deathLevelJump);
        }
        if (Input.GetKeyDown(KeyCode.Space)) JumpEffect();

    }
    private void JumpEffect()
    {
        Instantiate(bubbles, new Vector3(ball.transform.position.x, ball.transform.position.y-100, ball.transform.position.z), Quaternion.identity);
    }
    private void CollectOneCoin()
    {
        if (alive)
            coins += 1;
    }
    private void PrintCurrentScore()
    {
        GameObject.Find("WetBall").GetComponent<HealthAndScore>().objectScore.text = coins.ToString();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("coin")) 
        {
            CollectOneCoin(); 
            Destroy(col.gameObject);
            PrintCurrentScore();
        }
    }
}