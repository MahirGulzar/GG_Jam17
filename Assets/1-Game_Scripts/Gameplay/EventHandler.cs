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
    public Fading Fade;

    public List<GameObject> prompts = new List<GameObject>();
    public List<Vector2> promptPositions = new List<Vector2>();
    public List<GameObject> Responses = new List<GameObject>();

    public GameObject Overlay;
    public GameObject PauseMenu;
    public GameObject ResumeButton,MainMenuButton;

    public GameObject winScreen, LoseScreen;
    public GameObject Lightening;


    public int TotalDecisions;
    [Range(0, 15)]
    public int correctOnes;
    [Range(0, 15)]
    public int wrongeOnes;

    

    int currentIndex=0;

    public int DecisionCounter = 0;


    private void Start()
    {
        Fade.BeginFade(-1);
        //yield return new WaitForSeconds(fadeTime);

        TotalDecisions = Responses.Count;
    }


    private void Update()
    {
        
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
        Responses[currentIndex - 1].SetActive(false);
        character.Interacting = false;
        correctOnes++;
        DecisionCounter++;
        Configure_Environment();

    }

    public void Wronge()
    {
        prompts[currentIndex - 1].SetActive(false);
        Overlay.SetActive(false);
        Responses[currentIndex - 1].SetActive(false);
        character.Interacting = false;
        wrongeOnes++;
        DecisionCounter++;
        Configure_Environment();
    }


    void Configure_Environment()
    {
        Lightening.SetActive(true);
        StartCoroutine(doLight());
        float darkpercentage = (float)((float)wrongeOnes / (float)TotalDecisions);
        Darker.vignette.intensity = 1.5f * darkpercentage;

        float lightpercentage = (float)((float)correctOnes / (float)TotalDecisions);
        Lighter.settings.intensity = 0.25f * lightpercentage;

        if(DecisionCounter >= TotalDecisions)
        {
            character.Interacting = true;
            if (correctOnes>=10)
            {
                winScreen.SetActive(true);
                // Win..
                print("win..");
                
            }
            else
            {
                LoseScreen.SetActive(true);
                print("lose..");
                // Lose..
            }

            
            StartCoroutine(LoadDelayedScene());
        }
    }



    IEnumerator DelayDialogues()
    {
        yield return new WaitForSeconds(3f);
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
        SceneManager.LoadScene("MainMenuScene");
        Debug.Log("Main Menu funcitionality");
        float fadeTime=Fade.BeginFade(1);
        StartCoroutine(LoadSceneRoutine(fadeTime));
        
    }


    IEnumerator doLight()
    {

        yield return new WaitForSeconds(0.4f);
        Lightening.SetActive(false);
    }

    IEnumerator LoadSceneRoutine(float fadeTime)
    {
        Fade.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("MainMenuScene");
    }


    IEnumerator LoadDelayedScene()
    {
        yield return new WaitForSeconds(4f);
        float fadeTime = Fade.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("MainMenuScene");
    }



}
