using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Asylumjame.GlobalVariables;

//Updates the text based on articy controls
public class ReactiveText : MonoBehaviour
{
    private ArticyGlobalVariables globalVars;
    public UnityEngine.UI.Text targetText; //main text area
    //branch prefab's text object?

    public bool readabilityMode;

    //List of config objects for different text setups
    public List<TextConfigObject> textConfigs;
    public TextConfigObject readabilityConfig;

    private void Awake()
    {
        GetComponent<ArticyDebugFlowPlayer>().FlowIsUpdated += ConfigureText;
        globalVars = ArticyGlobalVariables.Default;
    }

    //Turn readability mode on or off
    public void SetReadability(bool set)
    {
        readabilityMode = set;
        if(readabilityMode)
        {
            targetText.font = readabilityConfig.font;
            targetText.material = readabilityConfig.material;
            targetText.alignment = readabilityConfig.alignment;
            targetText.fontSize = readabilityConfig.textSize;
            targetText.color = readabilityConfig.tintColour;
        }
        else
        {
            ConfigureText();
        }
    }

    //Set up the main text based on the config objects (set up for buttons/branches too?)
    public void ConfigureText()
    {
        if (!readabilityMode)
        {
            int i = globalVars.Technical.TextSet;
            targetText.font = textConfigs[i].font;
            targetText.material = textConfigs[i].material;
            targetText.alignment = textConfigs[i].alignment;
            targetText.fontSize = textConfigs[i].textSize;
            targetText.color = textConfigs[i].tintColour;
            //Debug.Log("Text is updated");
        }
    }
}
