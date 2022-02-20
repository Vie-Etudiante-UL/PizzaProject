using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] zombiePreFab;
    public float spawnTime = 1.0f;
    public float spwanDelay = 0.3f;
    [SerializeField] float duration = 1;
    public static bool spawnAllowed;
    public int ennemyCount, randZombie, randSpawnPoint;
    Vector2 spawnPoint;
    [SerializeField] Timer timer;
    public float bufferTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = new Timer(10000);
        timer.Play();
        spawnAllowed = true;
        //InvokeRepeating("SpwanNewEnemy, spawnTime, spwanDelay);
        StartCoroutine("zombieManager");

    }
    private void Update()
    {
        if(timer.Time - bufferTimer >= 10)
        {
            //ennemyCount++;
            bufferTimer = timer.Time;
        }
        Debug.Log(timer.Time);
    }
    void SpwanNewEnemy(int zombieCount){
        for (int i = 0; i < zombieCount; i++)
        {
            if (spawnAllowed)
            {
                randZombie = Random.Range(0, zombiePreFab.Length);
                randSpawnPoint = Random.Range(0, spawnPoints.Length);
                float randomTime = Random.Range(spwanDelay, spawnTime);
                Instantiate(zombiePreFab[randZombie], spawnPoints[randSpawnPoint].position, Quaternion.identity);
            }
        }
  
    }
    IEnumerator zombieManager()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(duration);
            Debug.Log("JE SUIS DANS LA COROUTINE");
            var a = (int)Random.Range(1, ennemyCount);
            SpwanNewEnemy(a);
        }

    }

}
