using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public static AudioClip laserSound, explosionSound;
    public static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        laserSound = Resources.Load<AudioClip>("laser");
        explosionSound = Resources.Load<AudioClip>("explosion");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch (clip){
            case "laser":
                audioSrc.PlayOneShot(laserSound);
                break;
            case "explosion":
                audioSrc.PlayOneShot(explosionSound);
                break;
            }
    }
}
