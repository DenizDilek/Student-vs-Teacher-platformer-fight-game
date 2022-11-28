using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        
    }
}
