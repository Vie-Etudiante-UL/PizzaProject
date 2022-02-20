using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.StartMusic();
    }

    public void OnApplicationQuit()
    {
        AudioManager.instance.PlayClic();
        Debug.Log("Quit");
        Application.Quit();
    }
    
    public void ToGame()
    {
        AudioManager.instance.PlayClic();
        SceneManager.LoadScene(1);
    }

}
