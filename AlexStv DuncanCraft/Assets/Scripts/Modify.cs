using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Modify : MonoBehaviour
{

    Vector2 rot;
    public LayerMask layerMask;

    public static Block currentBlockIn;
    public Block currentBlock;
    public static string displayBlock;
    public static bool inInvi = false;

    public Text blockOut;

    //public GameObject Invintory;


    private void Start()
    {
        currentBlock = new BlockGrass();
        blockOut.text = "Current Block: Grass";
    }

    private void FixedUpdate()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Invintory.SetActive(true);
            //currentBlock = new BlockGrass();
            //blockOut.text = "Current Block: Grass";
        //}
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBlock = new Block();
            blockOut.text = "Current Block: Stone";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBlock = new BlockLeaves();
            blockOut.text = "Current Block: Leaves";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentBlock = new BlockWood();
            blockOut.text = "Current Block: Wood";
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            currentBlock = new BlockCoal();
            blockOut.text = "Current Block: Coal Ore";
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            currentBlock = new BlockFlower();
            blockOut.text = "Current Block: Dandelion";
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            currentBlock = new BlockPlank();
            blockOut.text = "Current Block: Wood Plank";
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            currentBlock = new BlockGlass();
            blockOut.text = "Current Block: Glass";
        }*/

     
        if (currentBlockIn != null)
        {
            currentBlock = currentBlockIn;
            blockOut.text = "Current Block: " + displayBlock;
        }
        
    }


    void Update()
    {
        
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 4, layerMask))
            {
                EditTerrain.SetBlock(hit, new BlockAir());
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.forward, out hit, 4, layerMask))
            {
                EditTerrain.SetBlock(hit, currentBlock, true);
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