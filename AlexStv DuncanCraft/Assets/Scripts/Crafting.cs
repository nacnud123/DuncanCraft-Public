using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public List<Recipe> recipes;

    public void Start()
    {
        recipes = new List<Recipe>();

        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.sand, 12),         //0
                                new KeyValuePair<Craftable, int>(new BlockGlass(), 1)));    
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(new BlockWood(), 1),        //1
                    new KeyValuePair<Craftable, int>(new BlockPlank(), 4)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.seeds, 12),        //2
                                new KeyValuePair<Craftable, int>(new BlockFlower(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.cotton, 12),       //3
                                new KeyValuePair<Craftable, int>(new BlockGreenWool(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.cotton, 12),       //4
                                new KeyValuePair<Craftable, int>(new BlockRedWool(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.cotton, 12),       //5
                                new KeyValuePair<Craftable, int>(new BlockBlackWool(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.cotton, 12),       //6
                                new KeyValuePair<Craftable, int>(new BlockWhiteWool(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.coalOre, 5),       //7
                                new KeyValuePair<Craftable, int>(new BlockGoldWool(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(ItemList.cotton, 12),       //8
                                new KeyValuePair<Craftable, int>(new BlockBlueWool(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(new BlockGreenWool(), 1),   //9
                                new KeyValuePair<Craftable, int>(new BlockRedWool(), 1),
                                new KeyValuePair<Craftable, int>(new BlockBlackWool(), 1),
                                new KeyValuePair<Craftable, int>(new BlockWhiteWool(), 1),
                                new KeyValuePair<Craftable, int>(new BlockBlueWool(), 1),
                                new KeyValuePair<Craftable, int>(new BlockSpong(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(new BlockGoldWool(), 10),   //10
                    new KeyValuePair<Craftable, int>(new BlockDuncan(), 1)));
        recipes.Add(new Recipe(new KeyValuePair<Craftable, int>(new BlockPlank(), 2),            //11
                    new KeyValuePair<Craftable, int>(new BlockSlab(), 1)));
    }

    public void Craft(int itemToCraft)
    {
        if(!(itemToCraft > recipes.Count))
        {
            foreach(KeyValuePair<Craftable, int> component in recipes[itemToCraft].recipe)
            {
                if (!Inventory.InvContainsItem(component.Key) || !Inventory.InvHasEnoughItems(component.Key, component.Value))
                {
                    Debug.Log("Not enough items!");
                    return;
                }
            }

            foreach (KeyValuePair<Craftable, int> component in recipes[itemToCraft].recipe)
            {
                if (Inventory.inv.ContainsKey(Inventory.GetKeyOfType(component.Key)))
                {
                    Inventory.inv[Inventory.GetKeyOfType(component.Key)] -= component.Value;
                } else
                {
                    Inventory.items[component.Key] -= component.Value;
                }
            }

            Inventory.UpdateInventory(recipes[itemToCraft].result, recipes[itemToCraft].resultAmount);

            Debug.Log("Crafted " + recipes[itemToCraft].result);
            //return true;
        }

        Time.timeScale = 1;
        transform.gameObject.SetActive(false);
    }
}
