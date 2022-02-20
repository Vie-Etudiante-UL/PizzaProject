using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] public int playerLife = 10;
    public static PlayerLife instance;
    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : PlayerLife");
        instance = this;
    }

    private void Start()
    {
        changeLife();
    }
    public void changeLife()
    {
        HealthBar.instance.SetSize(playerLife);
    }
}
