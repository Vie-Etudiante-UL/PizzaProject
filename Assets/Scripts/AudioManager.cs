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
    public AudioClip wind, motor, city;
    
 
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

    public void PlayStart()
    {
        
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

    public void PauseAllSound()
    {
        AudioListener.pause = true;
    }

    public void ResumeAllSourd()
    {
        AudioListener.pause = false;
    }
    
}
