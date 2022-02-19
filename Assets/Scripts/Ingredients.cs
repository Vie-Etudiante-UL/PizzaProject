using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int id = 0;
    [SerializeField] Sprite sprite;
    [SerializeField] public KeyCode inputToEnter;
    bool isOnPizza = false;
    public static int counter = 0;
    public static int counterLayer;
    Pizza pizza;
    GameObject pizzaObj;
    GameObject[] ingrPlace;

    private void Start()
    {

        pizza = GameObject.FindGameObjectWithTag("pizza").GetComponent<Pizza>();
        counterLayer = pizza.listIngr.Count;
        counter = 0;
        pizzaObj = GameObject.FindGameObjectWithTag("pizza");
        GetComponent<SpriteRenderer>().sprite = sprite;
        ingrPlace = GameObject.FindGameObjectsWithTag("ingredients");
    }
    private void Update()
    {
        if (Input.GetKeyDown(inputToEnter) && !isOnPizza)
        {
            //Debug.Log(pizza.CompareLists<Ingredients>(pizza.bufferIngr, pizza.toPutOnPizza));
            if(pizza.toPutOnPizza.Find((x) => x.id == this.id) == null)
            {
                Debug.Log(gameObject.tag);
                if(gameObject.tag == "sauce")
                {
                    
                    ingrPlace[counter].GetComponent<SpriteRenderer>().sprite = sprite;
                    ingrPlace[counter].GetComponent<SpriteRenderer>().sortingOrder = 0;
                    counter++;
                    counterLayer--;
                }
                else
                {
                    ingrPlace[counter].GetComponent<SpriteRenderer>().sprite = sprite;
                    ingrPlace[counter].GetComponent<SpriteRenderer>().sortingOrder = counterLayer;
                    counter++;
                    counterLayer--;
                }
                //Debug.Log(pizza.toPutOnPizza.Find((x) => x.id == this.id));
                // ingredients added
                pizza.toPutOnPizza.Add(this);
                isOnPizza = true;
                
                if(pizza.CompareLists<Ingredients>(pizza.bufferIngr, pizza.toPutOnPizza))
                {
                    
                    pizza.isDone = true;
                    
                }
                
                

            }

        }

    }
}
