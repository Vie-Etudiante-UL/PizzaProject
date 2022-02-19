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

    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        //InvokeRepeating("SpwanNewEnemy, spawnTime, spwanDelay);
        SpwanNewEnemy();
    }


    void SpwanNewEnemy(){
        if (spawnAllowed){
            randZombie = Random.Range(0, zombiePreFab.Length);
            randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(zombiePreFab[randZombie], spawnPoints[randSpawnPoint].position, Quaternion.identity);
        }     
    }
}
