using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Recipe
{
    //Last item in recipe should be the resulting block and it's amount
    public Dictionary<Craftable, int> recipe;
    public Craftable result;
    public int resultAmount;

    public Recipe(params KeyValuePair<Craftable, int>[] components)
    {
        recipe = new Dictionary<Craftable, int>();
        result = new Block();
        resultAmount = 1;

        int index = 0;
        foreach(KeyValuePair<Craftable, int> component in components)
        {
            if(index == components.Length - 1)
            {
                result = component.Key;
                resultAmount = component.Value;
            } else
            {
                recipe.Add(component.Key, component.Value);
            }

            index++;
        }

    }
}
