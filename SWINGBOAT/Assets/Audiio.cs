﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class Audiio : MonoBehaviour
{
    public Sound[] sounds;
    public static Audiio instance;
    public AudioMixerGroup mixerGroup;
    void Awake(){

        if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = mixerGroup;
        }
        
    }
    void Start() 
    {
        Play("Theme");
    }
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sound "+ name + " not found!");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
            
        s.source.Play();
    }
    public void Stop (string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null) {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

        s.source.Stop ();
    }

    void Update() 
    {
        if (Input.GetButtonDown("Crouch")) {
             Play("Crouch");
             
         }
      
         if (Input.GetButtonUp("Crouch")) {
             Stop("Crouch");
         }

         if (Input.GetButtonDown("Horizontal")) {
             Play("PlayerWalk");
             
         }
      
         if (Input.GetButtonUp("Horizontal")) {
             Stop("PlayerWalk");
         }
    }
}
