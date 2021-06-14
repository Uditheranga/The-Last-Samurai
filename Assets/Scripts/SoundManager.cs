using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip jumpSound, coinPickUpsound;

    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {

      
        //jumpSound = Resources.Load<AudioClip>("Jump");
        coinPickUpsound = Resources.Load<AudioClip>("Coin");



        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip)
    {
        switch (clip){
            case "Jump":
                //audioSrc.PlayOneShot(jumpSound);
                break;

            case "Coin":
                audioSrc.PlayOneShot(coinPickUpsound);
                break;
           
        }
    }
}
