using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Scriptable object for containing presets for text settings able to be triggered by Articy flows
[CreateAssetMenu(menuName = "Text Configuration")][System.Serializable]
public class TextConfigObject : ScriptableObject
{
    [SerializeField]
    public Font font;
    [SerializeField]
    public Material material;
    [SerializeField]
    public TextAnchor alignment;
    [SerializeField]
    public int textSize;
    [SerializeField]
    public Color tintColour;
    /*[SerializeField]
    public AdditionalTextEffect additionalEffect;
    [SerializeField]
    public float additionalEffectIntensity;*/
}

//Might add this later for some CPU-side text modification
/*public enum AdditionalTextEffect
{
    None,
    Wobble,
    Flip,
    Vertigo,
}*/
