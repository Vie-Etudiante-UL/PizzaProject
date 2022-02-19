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
    public AudioManager audio;
    public bool pizzaStock;
    public int pizzaReady = 0;
    
    
    void Start()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        timer = timerValue;
        emptyFurnance = true;
        pizza.SetActive(false);
        door.SetActive(false);
        fire.SetActive(false);
        
        //TEMP
        pizzaStock = true;
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
            if (audio.isFurnancePlaying())
            {
                audio.StopFurnanceBurn();
            }
            fire.SetActive(false);
        }
    }

    IEnumerator loadPizza()
    {
        Debug.Log("Début load pizza");
        pizzaStock = false;
        door.SetActive(false);
        audio.PlayFurnanceOpen();
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
        audio.PlayFurnanceBurn(); 
        timer = timer - 1;

        if (timer == 0)
        {
            StartCoroutine(finishCook());
        }
    }

    IEnumerator finishCook()
    {
        fire.SetActive(false);
        audio.StopFurnanceBurn();
        audio.PlayFurnanceDing();
        pizzaReady++;
        emptyFurnance = true;
        timer = timerValue;
        door.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pizza.SetActive(false);
        yield return null;
    }
}
