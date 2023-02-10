using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpikeGeneration : MonoBehaviour
{
    [SerializeField] private GameObject spike;
    [SerializeField] private GameObject ball;
    private Dictionary<int, int[]> pos = new Dictionary<int, int[]>() { 
        {1,new [] {1,2,4,5,6,8 }},
        {2,new [] {1,2,3,4,7,8 }},
        {3,new [] { 3, 4, 5, 6, 7, 8 }},
        {4,new [] {4,5,6,12,12,12 }},
        {5, new [] {1,2,7,8,12,12}},
        {6,new [] {1,2,4,6,12,12}},
        {7, new [] {7,8,3,4,12,12}}
    };
    List <GameObject> currentSpikes = new ();
    void CreateSpikesAndTypes(int i, int k, int IsLeft)
    {
        currentSpikes[i] = Instantiate(spike);
        currentSpikes[i].transform.position = new Vector3(spike.transform.position.x+1800*IsLeft,
            spike.transform.position.y + 120 * pos[k][i], spike.transform.position.z);
    }
    void Start()
    {
        int k = Random.Range(1, 7);
        for (int i=0; i<6;i++)
        {
            currentSpikes.Add(new GameObject());
            CreateSpikesAndTypes(i, k,0);
        }
    }
    private void DestroySpikes()
    {
        for (int i = 0; i < 6; i++)
            Destroy(currentSpikes[i]);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "spike":
                DestroySpikes();
                break;
            case "wall":
                int k = Random.Range(1, 7);
                DestroySpikes();
                if (ball.transform.position.x > 1000) 
                {
                    for (int i = 0; i < 6; i++)
                    {
                        CreateSpikesAndTypes(i, k, 0);
                    }
                    break;
                }
                for (int i = 0; i < 6; i++)
                {
                    CreateSpikesAndTypes(i, k, 1);
                    currentSpikes[i].transform.Rotate(new Vector3(0, 0, 180));
                }
                break;
        }
    }
}
