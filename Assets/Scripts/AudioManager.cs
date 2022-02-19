using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [Header("FX")]  
    public AudioSource fxSource;
    public AudioClip start, pizzaThrow, pizzaHit, pizzaTopping, furnanceBurn, furnanceDing, zombieHit, zombieBlarg, loose;

    [Header("Music")] //OK
    public AudioSource musicSource;
    public List<AudioClip> musics;
    public bool playMusic;

    [Header("Ambiant")] 
    public AudioSource ambiantSource;
    public AudioClip ambiantSound;
    
    //FX
    //C'est un peu démoniaque mais c'est plus simple pour les appeller ensuite
    public void PlayStart()
    {
        fxSource.PlayOneShot(start);
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
    
    public void PlayFurnanceBurn()
    {
        fxSource.PlayOneShot(furnanceBurn);
    }
    
    public void PlayFurnanceDing()
    {
        fxSource.PlayOneShot(furnanceDing);
    }
    
    public void PlayZombieHit()
    {
        fxSource.PlayOneShot(zombieHit);
    }

    public void PlayZombieBlarg()
    {
        fxSource.PlayOneShot(zombieBlarg);
    }

    public void PlayLoose()
    {
        fxSource.PlayOneShot(loose);
    }
 
    
    //MUSIC
    void Start()
    {
        if (playMusic)
        {
            StartMusic();
        }
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

    void StartMusic()
    {
        int trackNum = Random.Range(0, musics.Count);
        musicSource.PlayOneShot(musics[trackNum]);
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    
    //AMBIANT
    //Loop un seul fichier 
    public void StartAmbiant()
    {
        ambiantSource.loop = true;
        ambiantSource.clip = ambiantSound;
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
