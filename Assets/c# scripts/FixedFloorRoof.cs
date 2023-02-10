using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedFloorRoof : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private bool isRoof;
    private Vector3 cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.transform.position;
        if (isRoof)
            transform.position = new Vector3(transform.position.x, cam.y+1080/2, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x, cam.y - 1080 / 2, transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}
