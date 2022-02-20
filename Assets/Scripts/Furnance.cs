using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Furnance : MonoBehaviour
{

    public int timerValue = 6000;
    public float timer;
    public KeyCode keyActivateFurnance;
    public bool emptyFurnance;
    public GameObject door, fire, pizza;
    private AudioManager audioManager;
    public GameObject gameManager;
    private Pizza pizzaManager;
    public bool pizzaStock = false;
    public int pizzaReady = 0;
    
    
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        pizzaManager = GameObject.Find("Pizza").GetComponent<Pizza>();
        timer = timerValue;
        emptyFurnance = true;
        pizza.SetActive(false);
        door.SetActive(false);
        fire.SetActive(false);
    }
    

    void Update()
    {
        GetInputs();
    }
    
    
    private void GetInputs()
    {
        if (Input.GetKeyDown(keyActivateFurnance))
        {
            Debug.Log("Clic down");
            if (emptyFurnance && pizzaStock)
            {
                Debug.Log("lance load pizza");
                StartCoroutine(loadPizza());
            }
        }
        else if (Input.GetKey(keyActivateFurnance))
        {
            Debug.Log("Clic appuyé");
            if (!emptyFurnance)
            {
                cook();
            }
        }
        else
        {
            if (audioManager.isFurnancePlaying())
            {
                audioManager.StopFurnanceBurn();
            }
            fire.SetActive(false);
        }
    }

    IEnumerator loadPizza()
    {
        Debug.Log("Début load pizza");
        pizzaStock = false;
        door.SetActive(false);
        audioManager.PlayFurnanceOpen();
        yield return new WaitForSeconds(0.5f);
        pizza.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        door.SetActive(true);
        emptyFurnance = false;
        Debug.Log("fin load pizza");
        yield return null;
    }

    private void cook()
    {
        if (!fire.activeSelf)
        {
            fire.SetActive(true);
        }
        audioManager.PlayFurnanceBurn(); 
        timer = timer - 1;

        if (timer == 0)
        {
            StartCoroutine(finishCook());
        }
    }

    IEnumerator finishCook()
    {
        fire.SetActive(false);
        audioManager.StopFurnanceBurn();
        audioManager.PlayFurnanceDing();
        pizzaReady++;
        emptyFurnance = true;
        timer = timerValue;
        door.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pizza.SetActive(false);
        //pizzaManager.isDone = false;
        PizzaLauncher.instance.pizzaMunitions++;
        UIManager.instance.changeMunitionsNumber();
        gameManager.GetComponent<PizzaManager>().DestroyPizza();
        yield return null;
    }
}
