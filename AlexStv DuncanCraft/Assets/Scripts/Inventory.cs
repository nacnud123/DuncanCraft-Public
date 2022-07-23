using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //public Block blockTest;
    //public GameObject e;
    //private Text buttonText;
    public Text blockText;
    public int position;
    public List<Block> blocks;
    public static Dictionary<Craftable, int> inv;
    public static Dictionary<Craftable, int> items;
    

    public string displayText;

    public void Start()
    {
        inv = new Dictionary<Craftable, int>();
        items = new Dictionary<Craftable, int>();

        blocks.Add(new Block());//0
        blocks.Add(new BlockGrass());//1
        blocks.Add(new BlockGlass());//2
        blocks.Add(new BlockPlank());//3
        //
        blocks.Add(new BlockWood());//4
        blocks.Add(new BlockFlower());//5
        blocks.Add(new BlockLeaves());//6
        blocks.Add(new BlockCoal());//7
        //
        blocks.Add(new BlockGreenWool()); //8
        blocks.Add(new BlockRedWool()); //9
        blocks.Add(new BlockBlackWool()); //10
        blocks.Add(new BlockWhiteWool());//11
        //
        blocks.Add(new BlockSpong());//12
        blocks.Add(new BlockDuncan());//13
        blocks.Add(new BlockGoldWool());//14
        blocks.Add(new BlockBlueWool());//15
        //
        blocks.Add(new BlockSlab());//16
        blocks.Add(new BlockDirt());//16
        //
        blocks.Add(new BlockCrafting());//17

    }

    public void changeBlock()
    {

        Modify.currentBlockIn = blocks[position];
        Modify.displayBlock = displayText;

        //UpdateInventory(blocks[position], 1);
        if(blocks[position].GetName() == "Crafting Table")
        {
            UpdateInventory(new BlockCrafting(), 1);
        }

        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);        

    }

    public static void UpdateInventory(Craftable itemToAdd, int amountToAdd)
    {
        if (InvContainsItem(itemToAdd))
        {
            inv[GetKeyOfType(itemToAdd)] += amountToAdd;
        }
        else
        {
            inv.Add(itemToAdd, amountToAdd);
        }

        //PrintInventory();
    }

    public static void UpdateItems(Item itemToAdd, int amountToAdd)
    {
        if (items.ContainsKey(itemToAdd))
        {
            items[itemToAdd] += amountToAdd;
        }
        else
        {
            items.Add(itemToAdd, amountToAdd);
        }

        PrintInventory();
    }

    public static void PrintInventory()
    {
        Debug.Log("Inventory:");

        foreach(KeyValuePair<Craftable, int> blocks in inv)
        {
            Debug.Log(blocks.Key.GetName() + ": " + blocks.Value);
        }
    }

    public static bool InvContainsItem(Craftable itemToCheck)
    {
        foreach(KeyValuePair<Craftable, int> block in inv)
        {
            if(block.Key.GetName() == itemToCheck.GetName())
            {
                return true;
            }
        }

        foreach(KeyValuePair<Craftable, int> item in items)
        {
            if (item.Key.GetName() == itemToCheck.GetName())
            {
                return true;
            }
        }

        return false;
    }

    public static bool InvHasEnoughItems(Craftable itemToCheck, int amount)
    {
        if (InvContainsItem(itemToCheck))
        {
            int val;
            inv.TryGetValue(GetKeyOfType(itemToCheck), out val);
            if (val >= amount)
            {
                return true;
            }

            items.TryGetValue(itemToCheck, out val);
            if(val >= amount)
            {
                return true;
            }
        }

        return false;
    }

    public static Craftable GetKeyOfType(Craftable itemToGet)
    {
        if (InvContainsItem(itemToGet))
        {
            foreach (KeyValuePair<Craftable, int> block in inv)
            {
                if (block.Key.GetName() == itemToGet.GetName())
                {
                    return block.Key;
                }
            }

            foreach (KeyValuePair<Craftable, int> item in items)
            {
                if (item.Key.GetName() == itemToGet.GetName())
                {
                    return item.Key;
                }
            }
        }

        return null;
    }

    public static string GetItemsString()
    {
        string output = "Items: ";
        int index = 0;

        foreach(KeyValuePair<Craftable, int> item in items)
        {
            if(index == items.Count - 1)
            {
                output += item.Key.GetName() + ": " + item.Value;
            } else
            {
                output += item.Key.GetName() + ": " + item.Value + ", ";
            }

            index++;
        }

        return output;
    }
}
