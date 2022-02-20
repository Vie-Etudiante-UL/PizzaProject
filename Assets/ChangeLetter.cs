using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeLetter : MonoBehaviour
{
    private void Start()
    {
        //Debug.Log(transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMesh>().text);
        transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMesh>().text = GetComponent<Ingredients>().inputToEnter.ToString();
    }
}
