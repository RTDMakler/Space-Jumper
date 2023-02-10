using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour
{
    [SerializeField] private GameObject bubbles;
    [SerializeField] private GameObject ball;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bubbles, new Vector3(ball.transform.position.x, ball.transform.position.y-100, ball.transform.position.z), Quaternion.identity);
        }
    }
}
