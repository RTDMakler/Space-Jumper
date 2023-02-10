using UnityEngine;
using UnityEngine.EventSystems;

public class SoundForObjectByHover : MonoBehaviour
{
    private void Awake()
    {
        this.gameObject.AddComponent<AudioSource>();
        this.gameObject.GetComponent<AudioSource>().playOnAwake = false;
        this.gameObject.AddComponent<VolumeLevel>();
        this.gameObject.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("ForHoverButtons");
        AddTriggerToObject();
    }
    void AddTriggerToObject()
    {
        EventTrigger eventTrigger1 = this.gameObject.AddComponent<EventTrigger>();
        eventTrigger1.triggers.Add(CreateEventSetVolume());
        eventTrigger1.triggers.Add(CreateEventPlay());
    }
    EventTrigger.Entry CreateEventSetVolume()
    {
        EventTrigger.Entry entry = CreateDeffaulTrigger();
        entry.callback.AddListener((data) => { this.gameObject.GetComponent<VolumeLevel>().SetVolumeForButtons(); });
        return entry;
    }
    EventTrigger.Entry CreateEventPlay()
    {
        EventTrigger.Entry entry = CreateDeffaulTrigger();
        entry.callback.AddListener((data) => { this.gameObject.GetComponent<AudioSource>().Play(); });
        return entry;
    }
    EventTrigger.Entry CreateDeffaulTrigger()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        return entry;
    }
}
