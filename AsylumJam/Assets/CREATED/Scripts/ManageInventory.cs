using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Articy.Asylumjame.GlobalVariables;

//Manages our inventory, will add and remove icons as the story progresses
public class ManageInventory : MonoBehaviour
{
    //Articy tracking
    public ArticyDebugFlowPlayer flowPlayer;
    private ArticyGlobalVariables globalVars;

    //UI variables
    public GameObject inventoryIconPrefab;
    public GameObject inventoryPanel;

    //Internal record
    Dictionary<string, GameObject> inventory;

    //Item wrapper class
    [System.Serializable]
    public class Item
    {
        [SerializeField]
        public string itemName;
        [SerializeField]
        public Sprite itemIcon;
    }

    //editor list of wrappers for logging the name and a sprite for the inventory
    [SerializeField]
    public List<Item> itemReferences;

    private void Awake()
    {
        //Subscribe to flow updates to check for inventory changes (there's probably a more efficient option)
        flowPlayer.FlowIsUpdated += UpdateInventory;
        globalVars = ArticyGlobalVariables.Default;
        inventory = new Dictionary<string, GameObject>();
    }

    void UpdateInventory()
    {
        //go through each item bool, call for each respective itemName using CheckForItem
        //will need to add a couple of lines for every item in the game, and an item reference which is, essentially, stringly typed...
        
        //LANTERN
        int lanternAddRemove =  globalVars.Items.HasLantern ? 0 : 1;
        CheckForItem("Lantern", lanternAddRemove);
        //...
    }

    //checks if we already have an item and whether we were looking to add or remove it
    void CheckForItem(string itemName, int addRemove) //0 == add, 1 == remove
    {
        //check if you have the item.
        //if you do and it's not in the inventory, add it, set the corresponding sprite
        if (!inventory.ContainsKey(itemName) && addRemove == 0)
        {
            //query the references for the right item
            for (int i = 0; i < itemReferences.Count; i++)
            {
                if (itemReferences[i].itemName == itemName)
                {
                    AddItem(itemReferences[i]);
                    break;
                }
            }
        }
        else
        {
            //if you don't and it's in the inventory, remove it
            if (inventory.ContainsKey(itemName) && addRemove == 1)
            {
                RemoveItem(itemName);
            }
        }
    }

    //add the relevant item to the inventory
    void AddItem(Item item)
    {
        GameObject inst = Instantiate(inventoryIconPrefab, inventoryPanel.transform, false);
        inst.GetComponent<UnityEngine.UI.Image>().sprite = item.itemIcon;
        inventory.Add(item.itemName, inst);
    }

    //remove the relevant item from the inventory
    void RemoveItem(string itemName)
    {
        GameObject inst;
        inventory.TryGetValue(itemName, out inst);
        Destroy(inst);
        inventory.Remove(itemName);
    }
}
