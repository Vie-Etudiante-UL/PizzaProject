using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaRotation : MonoBehaviour
{
    [SerializeField] float speed = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.time));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "zombie")
        {
            Destroy(gameObject);
        }
    }
}
