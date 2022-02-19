using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] zombiePreFab;
    public float spawnTime = 1.0f;
    public float spwanDelay = 0.3f;

    public static bool spawnAllowed;
    public int ennemyCount, randZombie, randSpawnPoint;
    Vector2 spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        //InvokeRepeating("SpwanNewEnemy, spawnTime, spwanDelay);
        SpwanNewEnemy();
    }


<<<<<<< HEAD
    void SpwanNewEnemy(){   
=======
    void SpwanNewEnemy(){
>>>>>>> af2ad3d10527c2d3c1b1c7251549de4b85cee65b
        if (spawnAllowed){
            randZombie = Random.Range(0, zombiePreFab.Length);
            randSpawnPoint = Random.Range(0, spawnPoints.Length);
            float randomTime = randomTime.Range(spwanDelay, spawnTime);
            Instantiate(zombiePreFab[randZombie], spawnPoints[randSpawnPoint].position, Quaternion.identity);
        }     
    }


}
