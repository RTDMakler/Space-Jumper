using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTableMainMenu : MonoBehaviour
{
    static int n = BestScoreTableCounter.n;
    [SerializeField]private Text[] texts = new Text[n];

    void Start()
    {
        GameObject.Find("ScoreTable").GetComponent<BestScoreTableCounter>().Starting();
        for (int i=0;i<n;i++)
        {
            if (BestScoreTableCounter.nameTable[i]==null)
            {
                texts[i].text = "Empty"; 
            }
            else
            {
                texts[i].text = BestScoreTableCounter.nameTable[i] + '\t' + BestScoreTableCounter.scoreTable[i];
            }
        }
    }
}
