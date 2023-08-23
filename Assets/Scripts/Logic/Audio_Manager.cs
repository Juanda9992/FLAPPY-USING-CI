using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using DG.Tweening;

public class Audio_Manager : MonoBehaviour
{
    public static Audio_Manager instance;


    public  AudioClip death,key,door,portal,powerUp,hit,bomb,select,changeMenu,menuLoop,levelLoop;
    private  AudioSource source;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioMixerGroup sfx, music;
    // Start is called before the first frame update
    void Awake()
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
        hit = Resources.Load<AudioClip>("Hit");
        select = Resources.Load<AudioClip>("Select");
        bomb = Resources.Load<AudioClip>("Bomb");
        changeMenu = Resources.Load<AudioClip>("ChangeMenu");
        menuLoop = Resources.Load<AudioClip>("Menu_Loop");
        levelLoop = Resources.Load<AudioClip>("Game_Loop1");
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
            case "Hit":
                source.PlayOneShot(hit);
                break;
            case "Select":
                source.PlayOneShot(select);
                break;
            case "Bomb":
                source.PlayOneShot(bomb);
                break;
            case "ChangeMenu":
                source.PlayOneShot(changeMenu);
                break;
            default:
                Debug.Log("No sound avaliable for" + sound);
                break;
        }
    }

    public void ChangeVolume(float volume,bool sfxSrc = true)
    {
        if(sfxSrc)
        {
            sfx.audioMixer.SetFloat("sfxVol",volume);
        }
        else
        {
            music.audioMixer.SetFloat("musicVol",volume);
        }
    }

    public void FadeMusicVolumeIn(float time)
    {
        DOTween.defaultTimeScaleIndependent= true;
        music.audioMixer.DOSetFloat("musicVol",-80,time);
    }
    public void FadeMusicVolumeOut(float time)
    {
        music.audioMixer.DOSetFloat("musicVol",PlayerPrefs.GetFloat("musicVol"),time);
    }

    public void ChangeMusic(bool changeToLevelMusic = true)
    {
        AudioClip previousClip = musicSource.clip;
        if(changeToLevelMusic)
        {
            musicSource.clip = levelLoop;
        }
        else
        {
            musicSource.clip = menuLoop;
        }
        music.audioMixer.DOSetFloat("musicVol",PlayerPrefs.GetFloat("musicVol"),0.5f).SetDelay(2f);
        if(musicSource.clip != previousClip)
        {
            musicSource.Stop();
            musicSource.Play();
        }
    }
}
