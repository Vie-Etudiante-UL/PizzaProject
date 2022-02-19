using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[]  m_SpawnPoints;
    public GameObject[] m_zombiePreFab;
    public float spawnTime = 5f;
    public float spwanDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        SpwanNewEnemy()
    }


    void SpwanNewEnemy(){
        Instantiate(m_zombiePreFab, m_SpawnPoints[0].transform.position, Quaternion.identity); 
    }
}
