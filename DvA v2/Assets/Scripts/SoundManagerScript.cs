using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip backgroundSound, clickSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        backgroundSound = Resources.Load<AudioClip>("background");
        clickSound = Resources.Load<AudioClip>("click");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "background":
                audioSrc.PlayOneShot(backgroundSound);
                break;
            case "click":
                audioSrc.PlayOneShot(clickSound);
                break;
        }
    }
}
