using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSource : MonoBehaviour
{
    [Header("FX")] 
    public AudioMixer fxMixer;
    public AudioClip start, pizzaThrow, pizzaHit, pizzaTopping, furnanceBurn, furnanceDing, zombieHit, zombieBlarg, loose;

    [Header("Music")]
    public AudioMixer musicMixer;
    public List<AudioClip> musics;

    [Header("Ambiant")] 
    public AudioMixer ambiantMixer;
    public AudioClip wind, motor, city;
    
    
}
