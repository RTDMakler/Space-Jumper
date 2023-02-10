using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHoles : MonoBehaviour
{
    [SerializeField] private GameObject[] Holes;
    [SerializeField] private GameObject[] Candy;
    private void Start()
    {
        StartCoroutine(Spawner());
    }
    IEnumerator Spawner()
    {
        while (BallControlCoinMode.alive)
        {
            List<int> randoms = new List<int>() { Random.Range(-1, 4) };
            yield return new WaitForSeconds(2);
            while (randoms.Count < 4)
            {
                int curr = Random.Range(-1, 4);
                if (!randoms.Contains(curr)) randoms.Add(curr);
            }

            for (int i = 0; i < 3; i++)
            {
                GameObject newHoles = Instantiate(Holes[Random.Range(0, Holes.Length)],
                    new Vector2(600, randoms[i] * 200 - 250), Quaternion.identity);
                Destroy(newHoles, 7);
            }
            GameObject newCandy = Instantiate(Candy[Random.Range(0,Candy.Length)],
                new Vector2(600, randoms[^1] * 200 - 250), Quaternion.identity);
            Destroy(newCandy, 7);
        }
    }
}
