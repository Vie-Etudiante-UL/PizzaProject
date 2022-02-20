using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimateTruck : MonoBehaviour
{
    [SerializeField] float duration = 2.0f;
    [SerializeField] Vector3 MouvForce = new Vector3(2, 0, 0);
    [SerializeField] int vibrato = 2;
    [SerializeField] int randomness = 0;
    [SerializeField] bool snapping = false;
    [SerializeField] bool fadeOut = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakePosition(duration, strength: MouvForce, vibrato: vibrato, randomness: randomness, snapping: snapping, fadeOut: fadeOut).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
