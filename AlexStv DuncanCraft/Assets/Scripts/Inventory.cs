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
