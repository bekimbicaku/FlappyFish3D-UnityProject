using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip shootSound, swipeSound, upSound, coinSound, crashSound, waterSound, shieldSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        crashSound = Resources.Load<AudioClip>("crashSound");
        shieldSound = Resources.Load<AudioClip>("shieldSound");
        waterSound = Resources.Load<AudioClip>("waterSound");
        shootSound = Resources.Load<AudioClip>("shootSound");
        upSound = Resources.Load<AudioClip>("upSound");
        swipeSound = Resources.Load<AudioClip>("swipeSound");
        coinSound = Resources.Load<AudioClip>("coinSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "up":
                audioSrc.PlayOneShot(upSound);
                break;
            case "coin":
                audioSrc.PlayOneShot(coinSound);
                break;
            case "swipe":
                audioSrc.PlayOneShot(swipeSound);
                break;
            case "crash":
                audioSrc.PlayOneShot(crashSound);
                break;
            case "water":
                audioSrc.PlayOneShot(waterSound);
                break;
            case "shield":
                audioSrc.PlayOneShot(shieldSound);
                break;
        }
    }
}
