using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("FX")] 
    public AudioSource fxSource; 
    public AudioSource furnanceBurnSource;
    public AudioClip start, pizzaThrow, pizzaHit, pizzaTopping, furnanceOpen, furnanceBurnClip, furnanceDing, zombieHit1, zombieHit2, zombieBlarg, clic;
    public bool bufferFire = false;
    public int cycleZombie = 0;

    [Header("Music")] //OK
    public AudioSource musicSource;
    public AudioClip music;
    public AudioClip looseMusic;
    public bool playMusic = true;
    public bool isLost = false;

    [Header("Ambiant")] 
    public AudioSource ambiantSource;
    public AudioClip ambiantSound;
    
    public static AudioManager instance;
    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : AudioManager");
        instance = this;
    }
    
    //FX
    //C'est un peu démoniaque mais c'est plus simple pour les appeller ensuite
    public void PlayStart()
    {
        fxSource.PlayOneShot(start);
    }

    public void PlayClic()
    {
        fxSource.PlayOneShot(clic);
    }
    
    public void PlayPizzaThrow()
    {
        fxSource.PlayOneShot(pizzaThrow);
    }
    
    public void PlayPizzaHit()
    {
        fxSource.PlayOneShot(pizzaHit);
    }
    
    public void PlayPizzaTopping()
    {
        fxSource.PlayOneShot(pizzaTopping);
    }

    public void PlayFurnanceOpen()
    {
        fxSource.PlayOneShot(furnanceOpen);
    }
    
    public void InitFurnanceBurn()
    {
        furnanceBurnSource.clip = furnanceBurnClip;
        furnanceBurnSource.loop = true;
    }

    public bool isFurnancePlaying()
    {
        return furnanceBurnSource.isPlaying;
    }

    public void PlayFurnanceBurn()
    {
        if (!isFurnancePlaying() && !bufferFire)
        {
            bufferFire = true;
            StartCoroutine(PlayFurnanceBrurnDelayed());
        }
    }

    IEnumerator PlayFurnanceBrurnDelayed()
    {
        yield return new WaitForSeconds(1);
        furnanceBurnSource.Play();
        bufferFire = false;
        yield break;
    }

    public void StopFurnanceBurn()
    {
        if (isFurnancePlaying())
        {
            furnanceBurnSource.Stop();
        }
    }

    public void PlayFurnanceDing()
    {
        fxSource.PlayOneShot(furnanceDing);
    }
    
    public void PlayZombieHit()
    {
        if (cycleZombie == 0)
        {
            fxSource.PlayOneShot(zombieHit1);
            cycleZombie = 1;
        }
        else
        {
            fxSource.PlayOneShot(zombieHit2);
            cycleZombie = 0;
        }
    }

    public void PlayZombieBlarg()
    {
        fxSource.PlayOneShot(zombieBlarg);
    }

    public void PlayLoose()
    {
        fxSource.PlayOneShot(looseMusic);
    }
 
    
    //MUSIC
    void Start()
    {
        if (playMusic)
        {
            StartMusic();
        }
        else if (isLost)
        {
            PlayLoose();
        }
        
        InitAmbiant();
        if (GameObject.Find("GameManager") != null)
        {
            StartAmbiant();
        }
        InitFurnanceBurn();
    }

    private void Update()
    {
        //Extinction du son
        if (playMusic)
        {
            if (!musicSource.isPlaying)
            {
                StartMusic();
            }
        }
        else
        {
            if (musicSource.isPlaying)
            {
                StopMusic();
            }
        }
    }

    public void StartMusic()
    {
        musicSource.PlayOneShot(music);
    }
    
    public void StartLostMusic()
    {
        musicSource.PlayOneShot(looseMusic);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    
    //AMBIANT
    //Loop un seul fichier 

    public void InitAmbiant()
    {
        ambiantSource.loop = true;
        ambiantSource.clip = ambiantSound;
    }
    
    public void StartAmbiant()
    {
        Debug.Log("PIZAAAAAAAAA");
        ambiantSource.Play();
    }

    public void StopAmbiant()
    {
        ambiantSource.Stop();
    }

    public void PauseAmbiant()
    {
        ambiantSource.Pause();
    }

    
    //MISC
    public void PauseAllSound()
    {
        AudioListener.pause = true;
    }

    public void ResumeAllSourd()
    {
        AudioListener.pause = false;
    }
    
}
