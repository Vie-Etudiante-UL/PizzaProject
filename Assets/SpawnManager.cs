using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[]  m_SpawnPoints;
    public GameObject[] m_zombiePreFab;
    public float spawnTime = 5f;
    public float spwanDelay = 3f;
    public int ennemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpwanNewEnemy();
    }


    void SpwanNewEnemy(){
        int randEnemy = Random.Range(0, m_zombiePreFab.Length);
        int randSpawnPoint = Random.Range(0, m_SpawnPoints.Length);
        Instantiate(m_zombiePreFab[0], m_SpawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
