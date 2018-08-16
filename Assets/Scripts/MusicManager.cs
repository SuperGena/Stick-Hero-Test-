using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public bool isPlay;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }


    public void ChangeIsPlay()
    {
        isPlay = !isPlay;
    }


    void Start()
    {
        MusicSource.clip = MusicClip;
    }
	

    internal void Play()
    {
        if(isPlay)
        MusicSource.Play();
    }
}
