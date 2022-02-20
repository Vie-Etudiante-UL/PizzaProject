using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TMP_Text munitions;
    GameObject player;
    PizzaLauncher pizza;
    public static UIManager instance;
    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : PizzaLauncher");
        instance = this;
    }
    private void Start()
    {
        player = GameObject.Find("RayCast");
        pizza = player.GetComponent<PizzaLauncher>();
        munitions.text = pizza.pizzaMunitions + "";
    }
    public void changeMunitionsNumber()
    {
        munitions.text = pizza.pizzaMunitions + "";
    }

}
