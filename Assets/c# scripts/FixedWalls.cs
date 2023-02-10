using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedWalls : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private bool isLeftWall;
    private Vector3 cam;

    void Start()
    {
        cam = Camera.transform.position;
        if (isLeftWall)
        transform.position = new Vector3(cam.x-1920/2, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(cam.x+1920 / 2, transform.position.y, transform.position.z);
    }
}
