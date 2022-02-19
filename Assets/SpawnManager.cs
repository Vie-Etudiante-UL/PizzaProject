using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[]  m_SpawnPoints;
    public GameObject[] m_zombiePreFab;
    //public float spawnTime = 5f;
    //public float spwanDelay = 3f;
    public static bool m_spawnAllowed;
    public int m_ennemyCount, m_randZombie, m_randSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnAllowed = true;
        SpwanNewEnemy();
    }


    void SpwanNewEnemy(){
        if (m_spawnAllowed){
            m_randZombie = Random.Range(0, m_zombiePreFab.Length);
            m_randSpawnPoint = Random.Range(0, m_SpawnPoints.Length);
            Instantiate(m_zombiePreFab[m_randZombie], m_SpawnPoints[m_randSpawnPoint].position, Quaternion.identity);
        }     
    }
}
