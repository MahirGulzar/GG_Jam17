using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour {

    public void OnPause()
    {
        // Pause funcitionality
        Debug.Log("Pause funcitionality");
    }


    public void OnMainMenu()
    {
        // Main Menu funcitionality
        Debug.Log("Main Menu funcitionality");
        SceneManager.LoadScene("MainMenuScene");
    }
}
