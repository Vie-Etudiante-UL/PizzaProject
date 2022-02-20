using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class movetoleft : MonoBehaviour
{
    public float duration = 2;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(gameObject.transform.position.y - 2, gameObject.transform.position.y + 4), transform.position.z);
        var a = Random.Range(1, 6);
        transform.localScale = new Vector3(a, a, a);
        transform.DOMove(new Vector3(-100, gameObject.transform.position.y, 0), duration)
        .SetEase(Ease.OutQuint)
        .OnStepComplete(() =>
        {
            destroyIt();

        });
        
    }
    private void destroyIt()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
