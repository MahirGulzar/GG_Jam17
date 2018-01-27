using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CinematicEffects;

public class EventHandler : MonoBehaviour {

    public LensAberrations Darker;
    public Bloom Lighter;

    public List<GameObject> prompts = new List<GameObject>();
    public List<Vector2> promptPositions = new List<Vector2>();
    public List<GameObject> Responses = new List<GameObject>();

    public GameObject Overlay;

    public GameObject ThoughtBubble;
    public Text UIText;

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

        prompts[currentIndex].transform.FindChild("SpeechBubble").gameObject.SetActive(true);
        StartCoroutine(DelayDialogues());
        currentIndex++;
    }



    public void Right()
    {
        prompts[currentIndex - 1].SetActive(false);
        Overlay.SetActive(false);
        Responses[currentIndex - 1].SetActive(true);
        correctOnes++;
    }

    public void Wronge()
    {
        prompts[currentIndex - 1].SetActive(false);
        Overlay.SetActive(false);
        Responses[currentIndex - 1].SetActive(false);
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
    }


    public void OnMainMenu()
    {
        // Main Menu funcitionality
        Debug.Log("Main Menu funcitionality");
        SceneManager.LoadScene("MainMenuScene");
    }
    


}
