using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using Articy.Asylumjame.GlobalVariables;
using Articy.Unity;

//Logs our analytic events and sends them to the server
public class AnalyticsHandler : MonoBehaviour
{
    ArticyGlobalVariables globalVariables; //For storing the articy global variables
    public ArticyDebugFlowPlayer flowHandler; //our flow player, necessary as I have an event on there when we end a chapter

    //Lists of analytic events for each chapter
    [SerializeField]
    public List<AnalyticEvent> chapter1Events;

    [SerializeField]
    public List<AnalyticEvent> chapter2Events;

    //Wrapper for our analytic log and the bool we'll search for in articy global variables to map to
    [System.Serializable]
    public struct AnalyticEvent
    {
        [SerializeField]
        public string analyticCall; //What we're calling the event
        [SerializeField]
        public string articyVarCall; //The value we're tracking in Articy's global variables, this is the same as the variable name in Articy
    }

    private void Awake()
    {
        globalVariables = ArticyGlobalVariables.Default; //get the default global variables

        //subscribe to chapter update delegate to check the current chapter, this just means when the flow player says it's a new chapter, our chapter method will fire
        flowHandler.chapterUpdate += CompareChapters;
    }

    //Calls when we reach a new chapter and passes analytic data from the previous chapter's outcomes
    void CompareChapters(int chapterIndex)
    {
        switch(chapterIndex)
        {
            //CHAPTER 1
            case 1:
                //Needs to be in Dictionary <String, Object> format, so we need to convert our wrapper (and global var search) to that format
                //The string will be our label, the object is the content
                Dictionary<string, object> chapter1Parse = new Dictionary<string, object>(); //Make a new dictionary
                foreach (AnalyticEvent e in chapter1Events) //go through all the events in chapter 1
                {
                    //add the event to our dictionary, label it with what we call the event, provide the articy variable's value as content
                    chapter1Parse.Add(e.analyticCall, globalVariables.GetVariableByString<bool>(e.articyVarCall));
                    //Debug.Log(e.analyticCall + globalVariables.GetVariableByString<bool>(e.articyVarCall).ToString());
                }
                //Post the dictionary under the grouping name (in this case 'chapter 1 outcomes')
                //This should now show up in the analytics dashboard after it's successfully sent
                Analytics.CustomEvent("Chapter 1 Outcomes", chapter1Parse);
                break;

            //CHAPTER 2

            //Add additional chapters here as needed

            default:
                break;
        }
    }
}
