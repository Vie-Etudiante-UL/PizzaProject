using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSource : MonoBehaviour
{
    [Header("FX")] 
    public AudioClip start, pizzaThrow, pizzaHit, pizzaTopping, furnanceBurn, furnanceDing, zombieHit, zombieBlarg, loose;
    public AudioMixer fxMixer;

    [Header("Music")]
    public List<AudioClip> musics;
    public AudioMixer musicMixer;

    [Header("Ambiant")] 
    public AudioClip wind, motor, city;
    public AudioMixer ambiantMixer;
    
    

}
