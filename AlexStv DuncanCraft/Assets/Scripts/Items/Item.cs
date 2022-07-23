using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Craftable
{
    //public new string name = "Item";

    public Item(string itemName) : base()
    {
        name = itemName;
    }
}

public static class ItemList
{
    public static Item cotton = new Item("Cotton");
    public static Item sand = new Item("Sand");
    public static Item seeds = new Item("Seeds");

    //This one should not be given out randomly, it only comes from coal blocks
    public static Item coalOre = new Item("Coal Ore");

    public static KeyValuePair<Item, int> GetRandomItems()
    {
        //Don't forget to change the range to match the number of items above
        int item = Random.Range(0, 3);
        Item chosenItem;

        switch (item)
        {
            case 0:
                chosenItem = cotton;
                break;
            case 1:
                chosenItem = sand;
                break;
            case 2:
                chosenItem = seeds;
                break;
            default:
                chosenItem = sand;
                break;
        }

        int amount = Random.Range(1, 3);

        return new KeyValuePair<Item, int>(chosenItem, amount);
    }
}
