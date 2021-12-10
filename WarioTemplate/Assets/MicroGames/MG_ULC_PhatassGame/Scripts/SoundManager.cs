using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource stepsSource, keysSource;
    [SerializeField] private AudioClip step1Clip, step2Clip, keys1Clip, keys2Clip, keys3Clip;
    public bool step1, step2, keys1, keys2, keys3;
   
    // Methods for the Step Source
    public void PlayStep1()
    {
        stepsSource.clip = step1Clip;
        stepsSource.Play();
    }
    public void PlayStep2()
    {
        stepsSource.clip = step2Clip;
        stepsSource.Play();
    }
    
    // Methods for the Key Source
    public void PlayKeys1()
    {
        keysSource.clip = keys1Clip;
        keysSource.Play();
    }
    public void PlayKeys2()
    {
        keysSource.clip = keys2Clip;
        keysSource.Play();
    }
    public void PlayKeys3()
    {
        keysSource.clip = keys3Clip;
        keysSource.Play();
    }

    private void Update()
    {
        if (step1)
        {
            PlayStep1();
            step1 = false;
        }

        if (step2)
        {
            PlayStep2();
            step2 = false;
        }

        if (keys1)
        {
            PlayKeys1();
            keys1 = false;
        }

        if (keys2)
        {
            PlayKeys2();
            keys2 = false;
        }
        
        if (keys3)
        {
            PlayKeys3();
            keys3 = false;
        }
    }
}
