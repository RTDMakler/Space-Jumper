using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAndSave : MonoBehaviour
{
    public static int Load(string selectedOption)
    {
        return PlayerPrefs.GetInt(selectedOption);
    }
    public static float LoadFloat(string selectedOption)
    {
        return PlayerPrefs.GetFloat(selectedOption);
    }
    public static void Save(float num, string option)
    {
        PlayerPrefs.SetFloat(option, num);
    }
    public static void Save(int num, string option)
    {
        PlayerPrefs.SetInt(option, num);
    }
}
