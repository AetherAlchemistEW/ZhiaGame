using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Asylumjame.GlobalVariables;

//Communicates between the Articy Global variables for controlling the music and our FMOD project
public class ReactiveAudio : MonoBehaviour
{
    //private ArticyGlobalVariables globalVars;

    FMOD.Studio.EventInstance musicEvent;
    //FMOD Parameters
    FMOD.Studio.ParameterInstance musicRamp; //0 - fine, 1 - Hectic
    FMOD.Studio.ParameterInstance musicWinLose; //0 - Ignored, 1 - Lose, 2 - Win

    private bool musicActive = true;
    private int timelinePosition = 50000;

    //TEMPORARY, will be replaced with globalVars calls once implemented
    [Range(0,1)]
    public float ramp;

    //Turns music on and off
    public void ToggleMusic(bool setMusic)
    {
        musicActive = setMusic;

        if (musicActive)
        {
            FMOD.Studio.PLAYBACK_STATE play_state;
            musicEvent.getPlaybackState(out play_state);
            if (play_state != FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                musicEvent.start();
                ConfigureAudio();
                musicEvent.setTimelinePosition(timelinePosition);
            }
        }
        else
        {
            FMOD.Studio.PLAYBACK_STATE play_state;
            musicEvent.getPlaybackState(out play_state);
            if (play_state == FMOD.Studio.PLAYBACK_STATE.PLAYING)
            {
                musicEvent.getTimelinePosition(out timelinePosition);
                musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            }
        }
    }

    //Cleanup
    private void OnDestroy()
    {
        musicEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicEvent.release();
    }

    private void Awake()
    {
        GetComponent<ArticyDebugFlowPlayer>().FlowIsUpdated += ConfigureAudio;
        //globalVars = ArticyGlobalVariables.Default;

        //Set up an event for the music
        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        //Grab the necessary parameters 
        musicEvent.getParameter("Ramp", out musicRamp);
        musicEvent.getParameter("Win/Lose", out musicWinLose);
    }

    void ConfigureAudio()
    {
        //get audio ramp from global variables
        musicRamp.setValue(ramp);
        //musicWinLose.setValue();
    }
}
