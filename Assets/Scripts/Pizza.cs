using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{

    [SerializeField] public List<Ingredients> listIngr;
    [HideInInspector]
    public List<Ingredients> bufferIngr;

    public List<Ingredients> toPutOnPizza;
    public bool isDone = false;
    [SerializeField] List<GameObject> ingrPlace;
    // Start is called before the first frame update
    private void Start()
    {
        
        bufferIngr.Clear();
        for (int i = 0; i < listIngr.Count; i++)
        {
            
            var a = Instantiate(listIngr[i]);
            
            bufferIngr.Add(a.GetComponent<Ingredients>());
            a.transform.position = ingrPlace[i].transform.position;
            a.transform.parent = ingrPlace[i].transform;
        }
    }

    public bool CompareLists<T>(List<T> aListA, List<T> aListB)
    {
        if (aListA == null || aListB == null || aListA.Count != aListB.Count)
            return false;
        if (aListA.Count == 0)
            return true;
        Dictionary<T, int> lookUp = new Dictionary<T, int>();
        // create index for the first list
        for (int i = 0; i < aListA.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListA[i], out count))
            {
                lookUp.Add(aListA[i], 1);
                continue;
            }
            lookUp[aListA[i]] = count + 1;
        }
        for (int i = 0; i < aListB.Count; i++)
        {
            int count = 0;
            if (!lookUp.TryGetValue(aListB[i], out count))
            {
                // early exit as the current value in B doesn't exist in the lookUp (and not in ListA)
                return false;
            }
            count--;
            if (count <= 0)
                lookUp.Remove(aListB[i]);
            else
                lookUp[aListB[i]] = count;
        }
        // if there are remaining elements in the lookUp, that means ListA contains elements that do not exist in ListB
        return lookUp.Count == 0;
    }

}
