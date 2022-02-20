using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    private Transform bar;
    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : HealthBar");
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("life");
    }
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
