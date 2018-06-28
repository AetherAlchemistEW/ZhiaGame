using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handler for file saving/loading
public class SaveSystem : MonoBehaviour
{
    //The object save data is stored in and which executes the JSON conversion
    public SaveObject saveFile;

    //For tracking flow variables
    public GameObject flowPlayerHandler;
    public Articy.Unity.ArticyFlowPlayer rawFlowPlayer;

    //For gameplay settings
    public UnityEngine.UI.Toggle musicToggle;
    public UnityEngine.UI.Toggle readabilityMode;

    //For showing that we're saving/loading
    public GameObject loadIndicator;

    private void Awake()
    {
        //Check if we need to load the game or start fresh
        if (PlayerPrefs.GetInt("LoadGame") == 1)
        {
            //Debug.Log("Loading...");
            StartCoroutine("LoadGame");
        }
        else
        {
            //Debug.Log("Do not load");
            StartGame();
        }
    }

    //Load the game
    IEnumerator LoadGame()
    {
        //Set io to true so we don't start until it's done and turn on the indicator
        saveFile.io = true;
        loadIndicator.SetActive(true);
        //tell save file to load
        saveFile.Load();
        while(saveFile.io)
        {
            //Debug.Log("...");
            //we're loading, just wait
            yield return null;
        }
        //Done loading, pass out values and start
        loadIndicator.SetActive(false);
        rawFlowPlayer.startOn = saveFile.currentFlow;
        flowPlayerHandler.GetComponent<ArticyDebugFlowPlayer>().chapterIndex = saveFile.chapterIndex;
        StartGame();
    }

    //Saving game
    IEnumerator SaveGame()
    {
        //set io to true so we don't exit until it's done and turn on the indicator
        saveFile.io = true;
        loadIndicator.SetActive(true);
        //pass in values and tell save file to save
        saveFile.chapterIndex = flowPlayerHandler.GetComponent<ArticyDebugFlowPlayer>().chapterIndex;
        saveFile.currentFlow = rawFlowPlayer.CurrentObject;
        saveFile.Save();
        //Save the settings too
        int intFormMusic = musicToggle.isOn ? 1 : 0;
        int intFormReadability = readabilityMode.isOn ? 1 : 0;
        PlayerPrefs.SetInt("MusicEnabled", intFormMusic);
        PlayerPrefs.SetInt("ReadabilityMode", intFormReadability);
        while (saveFile.io)
        {
            //Debug.Log("...");
            //We're saving, just wait
            yield return null;
        }
        //Load the menu
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Save()
    {
        StartCoroutine("SaveGame");
    }

    void StartGame()
    {
        flowPlayerHandler.SetActive(true);
        SetToggleOptions();
    }

    //This will either load the settings or start them with defaults
    void SetToggleOptions()
    {
        int intFormMusic;
        if (PlayerPrefs.HasKey("MusicEnabled"))
        {
            intFormMusic = PlayerPrefs.GetInt("MusicEnabled");
        }
        else
        {
            intFormMusic = 1;
        }
        int intFormReadability;
        if (PlayerPrefs.HasKey("MusicEnabled"))
        {
            intFormReadability = PlayerPrefs.GetInt("ReadabilityMode");
        }
        else
        {
            intFormReadability = 0;
        }

        musicToggle.isOn = intFormMusic == 1 ? true : false;
        readabilityMode.isOn = intFormReadability == 1 ? true : false;

        //Since they trigger events, but they're disabled by default, we need to manually fire these off
        FindObjectOfType<ReactiveAudio>().ToggleMusic(musicToggle.isOn);
        FindObjectOfType<ReactiveText>().SetReadability(readabilityMode.isOn);
    }
}
