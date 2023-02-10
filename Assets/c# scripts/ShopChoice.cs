using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopChoice : MonoBehaviour
{
    #region Awake + переменные
    [SerializeField] private string objectName;
    [SerializeField] private int price, access;
    [SerializeField] private GameObject block;
    [SerializeField] private Text objectPrice;
    [SerializeField] private int buttonNum;
    private void Awake()
    {
        AccessUpdate();
    }
    #endregion
    void AccessUpdate()
    {
        access = PlayerPrefs.GetInt(User.UserName+objectName + "Access");
        objectPrice.text = price.ToString();
        if (access == 1)
        {
            block.SetActive(false);
            objectPrice.gameObject.SetActive(false);
        }
    }
    public void OnButtonDown()
    {
        int coins = PlayerPrefs.GetInt(User.UserName + "coins");
        if (access == 0)
        {
            if (coins >=price)
            {
                PlayerPrefs.SetInt(User.UserName + objectName + "Access", 1);
                PlayerPrefs.SetInt(User.UserName+"coins", coins - price);
                AccessUpdate();
            }
        }
        else
        {
            SaveButtonNum();
        }
    }
    private void SaveButtonNum()
    {
        PlayerPrefs.SetInt(User.UserName + "selectedOption", buttonNum);
    }
}
