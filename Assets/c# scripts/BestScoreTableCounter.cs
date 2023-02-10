using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreTableCounter : MonoBehaviour
{
    public static int n = 5;
    public static int[] scoreTable = new int[n];
    public static string[] nameTable = new string[n];


    public void Starting()
    {
        for (int i = 0; i < n; i++)
        {
            if (PlayerPrefs.GetInt(i + "score") >= 1)
            {
                scoreTable[i] = PlayerPrefs.GetInt(i + "score");
                nameTable[i] = PlayerPrefs.GetString(i + "name");
            }

        }
    }
    int IfExistEmpty()
    {
        for (int j = 0; j < n; j++)
        {
            if (nameTable[j] == null)
                return j;
        }
        return -1;
    }
    void SaveData(int posSlot, int score, string UserName)
    {
        scoreTable[posSlot] = score;
        nameTable[posSlot] = UserName;
        PlayerPrefs.SetInt(posSlot + "score", score);
        PlayerPrefs.SetString(posSlot + "name", UserName);
        PlayerPrefs.Save();
    }
    public void GetNewRecord(string UserName, int score)
    {
        int posOfEmptySlot = IfExistEmpty();
        if(posOfEmptySlot != -1)
        {
            SaveData(posOfEmptySlot, score, UserName);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                if (scoreTable[i] < score)
                {
                    SaveData(i, score, UserName);
                    break;
                }
            }
        }
        
    }
}
