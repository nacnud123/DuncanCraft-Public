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
    

    public string displayText;

    public void Start()
    {
        blocks.Add(new Block());
        blocks.Add(new BlockGrass());
        blocks.Add(new BlockGlass());
        blocks.Add(new BlockPlank());
        blocks.Add(new BlockWood());
        blocks.Add(new BlockFlower());
        blocks.Add(new BlockLeaves());
        blocks.Add(new BlockCoal());
    }

    public void changeBlock()
    {

        Modify.currentBlockIn = blocks[position];
        Modify.displayBlock = displayText;
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);



        /*if (blockText.text == "Stone")
        {
            Modify.currentBlockIn = new Block();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            transform.parent.gameObject.SetActive(false);
            //Modify.inInvi = false;

        }
        else if (blockText.text == "Grass")
        {
            Modify.currentBlockIn = new BlockGrass();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }
        else if (blockText.text == "Glass")
        {
            Modify.currentBlockIn = new BlockGlass();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }
        else if (blockText.text == "Wood Planks")
        {
            Modify.currentBlockIn = new BlockPlank();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }
        else if (blockText.text == "Logs")
        {
            Modify.currentBlockIn = new BlockWood();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }
        else if (blockText.text == "Flower")
        {
            Modify.currentBlockIn = new BlockFlower();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }
        else if (blockText.text == "Leaves")
        {
            Modify.currentBlockIn = new BlockLeaves();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }
        else if (blockText.text == "Coal Ore")
        {
            Modify.currentBlockIn = new BlockCoal();
            Modify.displayBlock = displayText;
            Time.timeScale = 1;
            //Modify.inInvi = false;
            transform.parent.gameObject.SetActive(false);
        }*/

    }

}
