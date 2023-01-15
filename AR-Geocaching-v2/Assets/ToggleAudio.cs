using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject audio;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void toggle()
    {
        if (audio.activeInHierarchy)
            audio.SetActive(false);
        else
            audio.SetActive(true);
    }
}
