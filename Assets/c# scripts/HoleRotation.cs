using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleRotation : MonoBehaviour
{
    private GameObject[] Holes;
    void Update()
    {
       Holes = GameObject.FindGameObjectsWithTag("hole");
        foreach (GameObject hole in Holes)
            hole.transform.Rotate(0, 0, -4);
    }
}
