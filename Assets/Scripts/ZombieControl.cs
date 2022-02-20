using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ZombieControl : MonoBehaviour
{
    public float speed = 20;
    public Transform playerPosition;
    void Start()
    {
        playerPosition = PlayerLife.instance.gameObject.transform;
        transform.DOMove(playerPosition.position, 20)
        .SetEase(Ease.OutQuint)
        .SetLoops(-1, LoopType.Yoyo);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = PlayerLife.instance.gameObject.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("IS TRIGGER");
            PlayerLife.instance.playerLife--;
            AudioManager.instance.PlayZombieHit();
            PlayerLife.instance.changeLife();
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "projectile")
        {
            GetComponent<Animator>().SetBool("isDead", true);
            GetComponent<BoxCollider>().enabled = false;
            AudioManager.instance.PlayZombieBlarg();
            Destroy(gameObject, 1);
        }
    }
}
