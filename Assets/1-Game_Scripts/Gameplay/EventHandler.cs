using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CinematicEffects;

public class EventHandler : MonoBehaviour {

    public LensAberrations Darker;
    public Bloom Lighter;
    public CharacterScript character;

    public List<GameObject> prompts = new List<GameObject>();
    public List<Vector2> promptPositions = new List<Vector2>();
    public List<GameObject> Responses = new List<GameObject>();

    public GameObject Overlay;
    public GameObject PauseMenu;
    public GameObject ResumeButton,MainMenuButton;


    public int TotalDecisions;
    [Range(0, 15)]
    public int correctOnes;
    [Range(0, 15)]
    public int wrongeOnes;

    

    int currentIndex=0;


    private void Start()
    {
        TotalDecisions = Responses.Count;
    }


    private void Update()
    {
        Configure_Environment();
    }



    public void DoPrompt()
    {
        character.Interacting = true;
        prompts[currentIndex].transform.FindChild("SpeechBubble").gameObject.SetActive(true);
        StartCoroutine(DelayDialogues());
        currentIndex++;
    }



    public void Right()
    {
        prompts[currentIndex - 1].SetActive(false);
        Overlay.SetActive(false);
        Responses[currentIndex - 1].SetActive(true);
        character.Interacting = false;
        correctOnes++;
    }

    public void Wronge()
    {
        prompts[currentIndex - 1].SetActive(false);
        Overlay.SetActive(false);
        Responses[currentIndex - 1].SetActive(false);
        character.Interacting = false;
        wrongeOnes++;
    }


    void Configure_Environment()
    {
        float darkpercentage = (float)((float)wrongeOnes / (float)TotalDecisions);
        Darker.vignette.intensity = 2 * darkpercentage;

        float lightpercentage = (float)((float)correctOnes / (float)TotalDecisions);
        Lighter.settings.intensity = 2 * lightpercentage;
    }



    IEnumerator DelayDialogues()
    {
        yield return new WaitForSeconds(1f);
        Overlay.SetActive(true);
        Responses[currentIndex - 1].SetActive(true);


    }

    //-------------------------------------------


   

    //-------------------------------------------

    //void

    public void OnPause()
    {
        // Pause funcitionality
        Debug.Log("Pause funcitionality");
        Overlay.SetActive(true);
        PauseMenu.SetActive(true);
        ResumeButton.GetComponent<TweenScale>().ResetAndPlay();
        MainMenuButton.GetComponent<TweenScale>().ResetAndPlay();
        
        Time.timeScale = 0;

    }

    public void OnResume()
    {
        // Pause funcitionality
        Time.timeScale = 1;
        Overlay.SetActive(false);
        PauseMenu.SetActive(false);
        Debug.Log("Resume funcitionality");

    }


    public void OnMainMenu()
    {
        // Main Menu funcitionality
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        Debug.Log("Main Menu funcitionality");
        SceneManager.LoadScene("MainMenuScene");
    }
    


}
