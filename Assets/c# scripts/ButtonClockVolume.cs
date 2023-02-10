using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClockVolume : MonoBehaviour
{
   public AudioSource myFx;
   public AudioClip onClick;
    public AudioClip onHover;
    // Start is called before the first frame update
    public void ClickSound()
    {
        myFx.PlayOneShot(onClick);
    }
    public void HoverSound()
    {
        myFx.PlayOneShot(onHover);
    }

}
