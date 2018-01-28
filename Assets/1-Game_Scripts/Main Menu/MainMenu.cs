using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject soundManager;
    public Fading Fade;
    public bool inCredits = false;


    public GameObject MenuItems, Credits, Quote;
    public Text CreditsText;

    private void Awake()
    {
        if(GameObject.Find("SoundManager(Clone)") ==null)
        {
            GameObject temp = Instantiate(soundManager);
            DontDestroyOnLoad(temp);
        }
    }

    private void Start()
    {
        Fade.BeginFade(-1);
        if (!SoundManager.Instance.Looper.isPlaying)
            SoundManager.Instance.PlayBackGround(0);
    }


    private void Update()
    {
        if(inCredits)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                inCredits = false;
                MenuItems.SetActive(true);
                Credits.SetActive(false);
            }
        }
    }


    public void OnPlay()
    {
        // play funcitionality
        Debug.Log("play funcitionality");
        MenuItems.SetActive(false);
        Quote.SetActive(true);
        StartCoroutine(LoadSceneRoutine());
    }


    IEnumerator LoadSceneRoutine()
    {
        
        yield return new WaitForSeconds(7.4f);
        float fadeTime= Fade.BeginFade(1);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene("Gameplay");
    }

    public void OnQuit()
    {
        // Quit funcitionality
        Application.Quit();
        Debug.Log("quit funcitionality");
    }


    public void OnCredits()
    {
        inCredits = true;
        MenuItems.SetActive(false);
        CreditsText.GetComponent<TweenPosition>().ResetAndPlay();
        Credits.SetActive(true);
    }

    public void OnCreditsOver()
    {
        inCredits = false;
        MenuItems.SetActive(true);
        Credits.SetActive(false);

    }
}
