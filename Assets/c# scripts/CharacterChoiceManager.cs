using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterChoiceManager : MonoBehaviour
{
    [SerializeField] private CharacterDatabase characterDB;
    public SpriteRenderer spriteOriginal;

    private int selectedOption;
    void Start()
    {
        if (!PlayerPrefs.HasKey(User.UserName+"selectedOption"))
        {
            selectedOption = 0;
            UpdateCharacter(selectedOption);
        }
        else
        {
            Load();
            UpdateCharacter(selectedOption);
        }
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        spriteOriginal.sprite = character.characterSprite;
    }
    public void Load()
    {
        selectedOption  = LoadAndSave.Load(User.UserName+"selectedOption");
    }
}
