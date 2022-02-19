using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    [SerializeField] List<GameObject> PizzaPattern;
    GameObject currentPizza;
    [SerializeField] GameObject pizzaPosition;
    // Start is called before the first frame update
    void Start()
    {
        currentPizza = Instantiate(PizzaPattern[Random.Range(0, PizzaPattern.Count-1)], transform.parent);
        currentPizza.transform.position = pizzaPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPizza.GetComponent<Pizza>().isDone)
        {
            Destroy(currentPizza);
            currentPizza = Instantiate(PizzaPattern[Random.Range(0, PizzaPattern.Count - 1)], transform.parent);
            currentPizza.transform.position = pizzaPosition.transform.position;

        }
    }
}
