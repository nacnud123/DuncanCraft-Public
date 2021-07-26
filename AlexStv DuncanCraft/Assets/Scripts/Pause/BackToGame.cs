using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToGame : MonoBehaviour
{

    public void Back()
    {
        Time.timeScale = 1;
        transform.parent.gameObject.SetActive(false);
    }


}
