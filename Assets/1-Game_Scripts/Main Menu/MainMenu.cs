using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {



    public void OnPlay()
    {
        // play funcitionality
        Debug.Log("play funcitionality");
        SceneManager.LoadScene("GameplayScene");
    }

    public void OnQuit()
    {
        // Quit funcitionality
        Debug.Log("quit funcitionality");
    }


    public void OnOptions()
    {
        // Options funcitionality
        Debug.Log("options funcitionality");
    }
}
