using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaLauncher : MonoBehaviour
{
    public int pizzaMunitions = 10;
    [SerializeField] float speed = 1.2f;
    [SerializeField] GameObject pizza;
    [SerializeField] GameObject launcher;
    public static PizzaLauncher instance;
    Vector2 mouseOnScreen;
    Vector2 positionOnScreen;
    GameObject p;
    //[SerializeField] Material mat;
    [SerializeField] int minValue = -90;
    [SerializeField] int maxValue = 90;
    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : PizzaLauncher");
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
/*        if(pizzaMunitions != 10)
        {
            pizzaMunitions = 10;
        }*/
    }
    void FixedUpdate()
    {
        //Get the Screen positions of the object
        positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        //Get the Screen position of the mouse
        mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
        angle = Mathf.Clamp(angle, minValue, maxValue);
        launcher.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + 90f));
        Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0, 1.0f, 0.0f)) * 1000.0f, Color.yellow);
    }
    // Update is called once per frame
    void Update()
    {
        var position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Debug.Log(position);
        if (Input.GetButtonDown("Fire1") && pizzaMunitions > 0)
        {
            //Debug.Log("hello world");
            p = Instantiate(pizza, launcher.transform.position, transform.rotation);

            p.GetComponent<Rigidbody2D>().velocity = position * speed;
            pizzaMunitions--;
            UIManager.instance.changeScore();
            //Debug.Log(p.transform.forward * speed);
        }

    }
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
