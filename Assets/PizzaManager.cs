using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    [SerializeField] List<GameObject> PizzaPattern;
    GameObject currentPizza;
    [SerializeField] GameObject pizzaPosition;
    [SerializeField] GameObject furnace;
    // Start is called before the first frame update
    void Start()
    {
        furnace = GameObject.Find("furnance");
        currentPizza = Instantiate(PizzaPattern[Random.Range(0, PizzaPattern.Count-1)], transform.parent);
        currentPizza.transform.position = pizzaPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPizza.GetComponent<Pizza>().isDone)
        {

            currentPizza.transform.position = new Vector3(100, 100, 100);


        }
    }
    public void DestroyPizza()
    {
        //Debug.Log("JFIQDSJFIODS3");
        Destroy(currentPizza);
        currentPizza = null;
        currentPizza = Instantiate(PizzaPattern[Random.Range(0, PizzaPattern.Count - 1)], transform.parent);
        currentPizza.transform.position = pizzaPosition.transform.position;
    }
}
