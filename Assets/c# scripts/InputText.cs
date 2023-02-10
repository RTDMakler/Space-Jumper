using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    private string inputPass;
    private string inputLogIn;
    private string regLogIn;
    private string regPassWord;
    [SerializeField] private GameObject inputWindow;
    [SerializeField] private GameObject regWindow;
    [SerializeField] private Text text;
    void Start()
    {
        regWindow.SetActive(false);
        text.text = "";
    }
    public void ReadStringInputUserName(string str)
    {
        inputLogIn = str;  
    }
    public void ReadStringInputUserPass(string str)
    {
        inputPass = str;    
    }
    public void Submit()
    {
        string pass = PlayerPrefs.GetString(inputLogIn, "No Name");
        if ( pass== inputPass)
        {
            SceneManager.LoadScene("SampleScene");
            User.SetUserName(inputLogIn);
        }
        else
        {
            text.text = "Error";
        }
    }
    public void RegistrationUserName(string str)
    {
        regLogIn = str;
    }
    public void RegistrationPassWord(string str)
    {
        regPassWord = str;
    }
    public void SubmitRegistration()
    {
        if (!PlayerPrefs.HasKey(regLogIn) && regLogIn != "No Name" && regLogIn.Length >= 4)
        {
            PlayerPrefs.SetString(regLogIn, regPassWord);
            PlayerPrefs.Save();
            text.text = "Well Reg";
        }
        else if (PlayerPrefs.HasKey(regLogIn))
            text.text = "Name already exists";
        else
            text.text = "Error";
    }
    public void RegistrationWindow()
    {
        inputWindow.SetActive(false);
        regWindow.SetActive(true);
        text.text = "";
    }
    public void ReturnToLogIn()
    {
        inputWindow.SetActive(true);
        regWindow.SetActive(false);
        text.text = "";
    }
}
