using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Asylumjame;
using Articy.Unity;
using Articy.Asylumjame.GlobalVariables;
using System.IO;
using System.Text;
using System.Security.Cryptography;

//Stores all our save data and pushes/pulls to JSON file for persistence
//All articy global variables are manipulated from here (global),
//but progression tracking is pushed in/out by the save system (instanced).
[System.Serializable][CreateAssetMenu(menuName = "Save Object")]
public class SaveObject : ScriptableObject
{
    //Internal variables for the object
    [SerializeField]
    public bool io = false;
    [SerializeField]
    private string saveName = "save";

    //all articy story variables
    [SerializeField]
    bool Chp2_SpokeToFriend;

    //all articy item variables
    [SerializeField]
    bool hasLantern;

    //current articy flow
    [SerializeField]
    public ArticyRef currentFlow;
    [SerializeField]
    public int chapterIndex;

    public void Save()
    {
        //Set internal values from global variables

        //story events
        //Chp2_SpokeToFriend = ArticyGlobalVariables.Default.StoryEvents.Chp2_SpokeToFriend;
        //items
        hasLantern = ArticyGlobalVariables.Default.Items.HasLantern;

        //store save in a json file
        SaveJSON();
    }

    public void Load()
    {
        //load and override from json file
        LoadJSON();

        //Set global variables values from internal values

        //story events
        //ArticyGlobalVariables.Default.StoryEvents.Chp2_SpokeToFriend = Chp2_SpokeToFriend;
        //items
        ArticyGlobalVariables.Default.Items.HasLantern = hasLantern;
    }

    //Generates our hash key for some mild encryption
    string GenerateHash(string data)
    {
        string hash = string.Empty;

        //set up Sha
        SHA256Managed crypt = new SHA256Managed();

        //compute hash 
        byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(data), 0, Encoding.UTF8.GetByteCount(data));

        foreach (byte bit in crypto)
        {
            hash += bit.ToString("x2");
        }

        return hash;
    }

    //Exports our object as a JSON file
    public void SaveJSON()
    {
        lock (this)
        {
            string data = JsonUtility.ToJson(this, true);

            string hashKey = GenerateHash(data);
            //add save slot later
            PlayerPrefs.SetString("HashKey", hashKey);

            string saveStatePath = System.IO.Path.Combine(Application.persistentDataPath, saveName + ".json");
            File.WriteAllText(saveStatePath, data);
            io = false;
        }
    }

    //Imports our JSON file and overrides this object with its data (if the hash matches)
    public void LoadJSON()
    {
        lock (this)
        {
            //consider save slot later
            string saveStatePath = System.IO.Path.Combine(Application.persistentDataPath, saveName + ".json");
            if (File.Exists(saveStatePath) && PlayerPrefs.HasKey("HashKey"))
            {
                //make sure the hash code matches
                string json = File.ReadAllText(saveStatePath);
                //string data = JsonUtility.FromJson<string>(json);
                string hash = GenerateHash(json);

                string hashKey = PlayerPrefs.GetString("HashKey");
                //hashKey = hash;

                if (hash == hashKey)
                {
                    //Matching Hash
                    //string json = File.ReadAllText(saveStatePath);
                    JsonUtility.FromJsonOverwrite(json, this);
                }
                else
                {
                    Debug.Log("Data was modified");
                }
            }
            else
            {
                Save();
            }
            io = false;
        }
    }

    //The load failed, either due to corruption or hash mismatch
    public void FailedLoad()
    {
        //purge all save slots, give user a warning about data corruption or tampering, tell them to contact customer service regarding purchases
        string saveStatePath = System.IO.Path.Combine(Application.persistentDataPath, saveName + ".json");

        if (File.Exists(saveStatePath) && PlayerPrefs.HasKey("HashKey"))
        {
            PlayerPrefs.DeleteKey("HashKey");
            File.Delete(saveStatePath);
            Save();
        }
    }
}
