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
            //Debug.Log(pizza.CompareLists<Ingredients>(pizza.bufferIngr, pizza.toPutOnPizza));
            if(pizza.toPutOnPizza.Find((x) => x.id == this.id) == null)
            {
                Debug.Log(pizza.toPutOnPizza.Find((x) => x.id == this.id));
                // ingredients added
                pizza.toPutOnPizza.Add(this);
                isOnPizza = true;
                if(pizza.CompareLists<Ingredients>(pizza.bufferIngr, pizza.toPutOnPizza))
                {
                    //Debug.Log("hfuqidhfuqi");
                    pizza.isDone = true;
                }
                
            }

        }

    }
}
