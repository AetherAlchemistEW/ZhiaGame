using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

//Slide inventory in and out via timeline
public class ToggleInventory : MonoBehaviour
{
    public PlayableAsset closePlayable;
    public PlayableAsset openPlayable;

    public GameObject openButton;
    public GameObject closeButton;

    public void OpenInventory()
    {
        openButton.SetActive(false);
        closeButton.SetActive(true);
        GetComponent<PlayableDirector>().playableAsset = openPlayable;
        GetComponent<PlayableDirector>().Play();
    }

    public void CloseInventory()
    {
        openButton.SetActive(true);
        closeButton.SetActive(false);
        GetComponent<PlayableDirector>().playableAsset = closePlayable;
        GetComponent<PlayableDirector>().Play();
    }
}
