using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public bool isPaused = false;
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : GameManager");
        instance = this;
    }
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        AudioManager.instance.StartAmbiant();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
