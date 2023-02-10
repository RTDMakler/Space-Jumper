using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForNullShop : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.DeleteAll();
    }
}
