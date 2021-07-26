using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldName : MonoBehaviour
{
    public string worldName;
    // Start is called before the first frame update
    void Start()
    {
        
        worldName = "";
    }

    public void Gamer()
    {
        DontDestroyOnLoad(gameObject);
    }
}
