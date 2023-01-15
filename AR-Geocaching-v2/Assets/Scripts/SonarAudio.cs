using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonarAudio : MonoBehaviour
{
    public AudioSource myAudioSource;
    public Slider progressBar; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myAudioSource.volume = 1 - ((progressBar.value)/50);
    }
}
