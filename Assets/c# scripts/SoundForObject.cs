using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundForObject : MonoBehaviour
{
    GameObject SoundForCollision;
    private void Awake()
    {
        SoundForCollision = GameObject.Find("SoundForCollision");
        SoundForCollision.AddComponent<AudioSource>();
        SoundForCollision.AddComponent<VolumeLevel>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "hole")
            SetSound("BlackHoleSuck");
        else if (col.tag == "coin")
            SetSound("coin");
        
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "wall")
            SetSound("WallSound");
        else if (col.collider.tag == "spike")
            SetSound("spike");
    }
    void SetSound(string tag)
    {
        SoundForCollision.GetComponent<AudioSource>().PlayOneShot(Resources.Load<AudioClip>(tag), SoundForCollision.GetComponent<VolumeLevel>().SetVolume());
    }
}
