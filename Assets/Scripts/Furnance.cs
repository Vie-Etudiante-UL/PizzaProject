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
    public GameObject gameManager;
    private Pizza pizzaManager;
    public bool pizzaStock = false;
    public int pizzaReady = 0;
    public GameObject feedBackArrow;
    GameObject arrow;
    public int pizzaToHave = 3;
    
    
    void Start()
    {
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
            if (AudioManager.instance.isFurnancePlaying())
            {
                AudioManager.instance.StopFurnanceBurn();
            }
            fire.SetActive(false);
        }
        if(Input.GetKeyDown(keyActivateFurnance) && timer != 1000)
        {
            if(arrow != null)
            {
                arrow.SetActive(false);
            }
            Debug.Log("isthereanybody");
        }
        if (Input.GetKeyUp(keyActivateFurnance))
        {
            if (arrow != null)
            {
                arrow.SetActive(true);
            }
        }
    }

    IEnumerator loadPizza()
    {
        Debug.Log("Début load pizza");
        //Destroy(arrow);
        arrow.SetActive(false);
        //arrow = null;
        pizzaStock = false;
        door.SetActive(false);
        AudioManager.instance.PlayFurnanceOpen();
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
        AudioManager.instance.PlayFurnanceBurn(); 
        timer = timer - 1;

        if (timer == 0)
        {
            StartCoroutine(finishCook());
        }
    }

    IEnumerator finishCook()
    {
        fire.SetActive(false);
        AudioManager.instance.StopFurnanceBurn();
        AudioManager.instance.PlayFurnanceDing();
        pizzaReady++;
        emptyFurnance = true;
        timer = timerValue;
        door.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        pizza.SetActive(false);
        //pizzaManager.isDone = false;
        PizzaLauncher.instance.pizzaMunitions += pizzaToHave;
        UIManager.instance.changeMunitionsNumber();
        gameManager.GetComponent<PizzaManager>().DestroyPizza();
        Destroy(arrow);
        arrow = null;
        yield return null;
    }
    public void pizzaReadyToCook()
    {
        arrow = Instantiate(feedBackArrow);
        arrow.transform.position = new Vector3(transform.Find("Input").position.x - 10, transform.Find("Input").position.y, 0);
    }
}
