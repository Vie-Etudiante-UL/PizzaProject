using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int id = 0;
    [SerializeField] Sprite sprite;
    [SerializeField] KeyCode inputToEnter;
    bool isOnPizza = false;
    Pizza pizza;
    private void Start()
    {
        pizza = GameObject.FindGameObjectWithTag("pizza").GetComponent<Pizza>();
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
    private void Update()
    {
        if (Input.GetKeyDown(inputToEnter) && !isOnPizza)
        {
            Debug.Log(pizza.toPutOnPizza.Find((x) => x.id == this.id));
            if(pizza.toPutOnPizza.Find((x) => x.id == this.id) == null)
            {
                // ingredients added
                pizza.toPutOnPizza.Add(this);
                isOnPizza = true;
                if(pizza.CompareLists<Ingredients>(pizza.listIngr, pizza.toPutOnPizza))
                {
                    pizza.isDone = true;
                }
                
            }

        }

    }
}
