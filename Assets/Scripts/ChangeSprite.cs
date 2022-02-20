using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    Ingredients inputIngredient;
    public Sprite baseSprite;
    Vector3 originalScale;
    [SerializeField] Sprite downSprite;
    // Start is called before the first frame update
    void Start()
    {
        inputIngredient = transform.parent.gameObject.GetComponent<Ingredients>();
        baseSprite = GetComponent<SpriteRenderer>().sprite;
        originalScale = GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(inputIngredient.inputToEnter))
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
