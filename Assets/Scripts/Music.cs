using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public AudioSource musicSource; 

    
    public void stop()
    {
        musicSource.Stop(); 
    }

    
    public void play()
    {
        musicSource.Play(); 
    }
}
