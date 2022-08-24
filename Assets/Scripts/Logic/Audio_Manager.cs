using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;

    public static AudioClip death,key,door,portal,powerUp;
    private static AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        source = GetComponent<AudioSource>();

        death = Resources.Load<AudioClip>("Death");
        portal = Resources.Load<AudioClip>("Portal");
        door = Resources.Load<AudioClip>("Door");
        powerUp = Resources.Load<AudioClip>("PowerUp");
        key = Resources.Load<AudioClip>("Key");
    }

    public void PlaySound(string sound)
    {
        switch(sound)
        {
            case "Death":
                source.PlayOneShot(death);
                break;
            case "Portal":
                source.PlayOneShot(portal);
                break;
            case "Door":
                source.PlayOneShot(door);
                break;
            case "PowerUp":
                source.PlayOneShot(powerUp);
                break;
            case "Key":
                source.PlayOneShot(key);
                break;
            default:
                Debug.Log("No sound avaliable for" + sound);
                break;
        }
    }
}
