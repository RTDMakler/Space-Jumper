using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenHolesAndSweets : MonoBehaviour
{
    [SerializeField] private GameObject holePos;
    private float speed = 1f;
    private Vector3 point;
    private Vector3 axis;
    private float statndartSpeedMultiplier = 13f;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * (speed * Time.timeScale * statndartSpeedMultiplier), Space.World);
        if (CompareTag("coin")) return;
        point = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        axis = new Vector3(0, 0, 1);
        transform.RotateAround(point, axis, Time.deltaTime * UnityEngine.Random.Range(30, 200));
    }
}


