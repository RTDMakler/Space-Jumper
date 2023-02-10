using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public static string UserName { get; private set; }
    public static void SetUserName(string name)
    {
        UserName = name;
    }
}
