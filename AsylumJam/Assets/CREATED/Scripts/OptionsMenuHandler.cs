using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuHandler : MonoBehaviour
{
    public GameObject optionsPanel;
    private bool displayMenu = false;

    public void ToggleMenuDisplay()
    {
        displayMenu = !displayMenu;
        if(displayMenu)
        {
            ShowOptionsMenu();
        }
        else
        {
            HideOptionsMenu();
        }
    }

    void ShowOptionsMenu()
    {
        optionsPanel.SetActive(true);
    }

    void HideOptionsMenu()
    {
        optionsPanel.SetActive(false);
    }
}
