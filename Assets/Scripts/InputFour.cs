using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFour : MonoBehaviour
{
    // Start is called before the first frame update
    Furnance inputFur;
    public Sprite baseSprite;
    Vector3 originalScale;
    [SerializeField] Sprite downSprite;
    // Start is called before the first frame update
    void Start()
    {
        inputFur = transform.parent.gameObject.GetComponent<Furnance>();
        baseSprite = GetComponent<SpriteRenderer>().sprite;
        originalScale = GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputFur.keyActivateFurnance))
        {
            GetComponent<SpriteRenderer>().sprite = downSprite;

            GetComponent<RectTransform>().localScale = originalScale / 2;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = baseSprite;
            GetComponent<RectTransform>().localScale = originalScale;
        }
    }
}
