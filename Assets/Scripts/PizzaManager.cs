using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    [SerializeField] List<GameObject> PizzaPattern;
    GameObject currentPizza;
    [SerializeField] GameObject pizzaPosition;
    [SerializeField] GameObject pizzaReadyToCookPosition;
    [SerializeField] GameObject furnace;
    // Start is called before the first frame update
    void Start()
    {
        furnace = GameObject.Find("furnance");
        var a = PizzaPattern[Random.Range(0, PizzaPattern.Count)];
        currentPizza = Instantiate(a, transform.parent);
        currentPizza.transform.position = pizzaPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PizzaPattern[Random.Range(0, PizzaPattern.Count)]);
        if (currentPizza.GetComponent<Pizza>().isDone)
        {

            currentPizza.transform.position = pizzaReadyToCookPosition.transform.position;


        }
    }
    public void DestroyPizza()
    {
        //Debug.Log("JFIQDSJFIODS3");
        Destroy(currentPizza);
        currentPizza = null;
        var a = PizzaPattern[Random.Range(0, PizzaPattern.Count - 1)];
        Debug.Log("Numéro de la pizza" + a);
        currentPizza = Instantiate(PizzaPattern[Random.Range(0, PizzaPattern.Count - 1)], transform.parent);
        currentPizza.transform.position = pizzaPosition.transform.position;
    }
}
