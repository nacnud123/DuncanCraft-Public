using UnityEngine;
using System.Collections;
using TMPro;
using System.Collections.Generic;

public class Modify : MonoBehaviour
{

    //Vector2 rot;
    public LayerMask layerMask;

    public static Block currentBlockIn;
    public Block currentBlock;
    public static string displayBlock;
    public static bool inInvi = false;

    public TextMeshProUGUI blockOut;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpCon;

    //public GameObject Invintory;


    private void Start()
    {
        currentBlock = new BlockGrass();
        currentBlockIn = currentBlock;
        displayBlock = currentBlock.GetName();
        Inventory.inv.Add(currentBlock, 1);
        Inventory.PrintInventory();
        blockOut.text = "Current Block: Grass: 1";
        fpCon = GameObject.FindGameObjectWithTag("Player").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
    }

    private void FixedUpdate()
    {
     
        if (currentBlockIn != null)
        {
            currentBlock = currentBlockIn;
            if (Inventory.InvContainsItem(currentBlock))
            {
                blockOut.text = "Current Block: " + displayBlock + ": " + Inventory.inv[Inventory.GetKeyOfType(currentBlock)];
            } else
            {
                blockOut.text = "Current Block: " + displayBlock + ": 0";
            }
        }
        
    }


    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        //Break block
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 4, layerMask)
                /*&& !fpCon.GetMouseLook().paused*/)
            {
                Inventory.UpdateInventory(EditTerrain.GetBlock(hit), 1);

                if(EditTerrain.GetBlock(hit).GetName() == "Block of Coal")
                {
                    Inventory.UpdateItems(ItemList.coalOre, 1);
                }

                EditTerrain.SetBlock(hit, new BlockAir());
                KeyValuePair<Item, int> items = ItemList.GetRandomItems();
                Inventory.UpdateItems(items.Key, items.Value);
            }
        }

        //Place block/Interact
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 4, layerMask))
            {
                //Debug.Log(EditTerrain.GetBlock(hit).interactable);

                if (EditTerrain.GetBlock(hit).interactable)
                {
                    fpCon.PauseOnWindow(fpCon.craft, UnityStandardAssets.Characters.FirstPerson.FirstPersonController.Window.craft);
                } else if(Inventory.InvContainsItem(currentBlock))
                {
                    if(Inventory.inv[Inventory.GetKeyOfType(currentBlock)] > 0)
                    {
                        EditTerrain.SetBlock(hit, currentBlock, true);

                        Inventory.UpdateInventory(currentBlock, -1);
                    }
                }
                
            }
        }
        
        

        /*rot = new Vector2(
            rot.x + Input.GetAxis("Mouse X") * 3,
            rot.y + Input.GetAxis("Mouse Y") * 3);

        transform.localRotation = Quaternion.AngleAxis(rot.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rot.y, Vector3.left);

        transform.position += transform.forward * 3 * Input.GetAxis("Vertical");
        transform.position += transform.right * 3 * Input.GetAxis("Horizontal");*/
    }
}