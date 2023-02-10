using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Promo : MonoBehaviour
{
    [SerializeField] private Text text;
    private int Promo1;
    private int Promo2;

    private void Start()
    {
        Promo1 = PlayerPrefs.GetInt(User.UserName + "Promo1");
        Promo2 = PlayerPrefs.GetInt(User.UserName + "Promo2");
    }
    public void CheckValid()
        {
        if (text.text == "Sasha" && Promo1 == 0)
        {
            PlayerPrefs.SetInt(User.UserName + "coins", PlayerPrefs.GetInt(User.UserName + "coins") + 240);
            PlayerPrefs.SetInt(User.UserName + "Promo1", 1);
        }
        else if (text.text == "Mon" && Promo2 == 0)
        {
            PlayerPrefs.SetInt(User.UserName + "coins", PlayerPrefs.GetInt(User.UserName + "coins") + 1000);
            PlayerPrefs.SetInt(User.UserName + "Promo2", 1);
        }
        text.text = "";
        }
}