using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public UnityEngine.UI.Button continueButton;

    private void Awake()
    {
        //look for an existing save
        if(PlayerPrefs.HasKey("HashKey"))
        {
            //Debug.Log("There is a hash");
            continueButton.interactable = true;
        }
        else
        {
            //Debug.Log("There is no hash");
            continueButton.interactable = false;
        }
    }

    public void NewGame()
    {
        //load the game scene
        PlayerPrefs.SetInt("LoadGame", 0);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        //set the Articy game and item variables based on the save file
        //load the game scene
        PlayerPrefs.SetInt("LoadGame", 1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
