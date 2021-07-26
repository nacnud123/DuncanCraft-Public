using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigInvintory : MonoBehaviour
{
    public Modify playerModify;
    private void OnEnable()
    {
        playerModify = FindObjectOfType<Modify>();
        Modify.inInvi = true;
        playerModify.enabled = false;
        print(Modify.inInvi);
    }
    private void OnDisable()
    {
        playerModify = FindObjectOfType<Modify>();
        Modify.inInvi = false;
        playerModify.enabled = true;
        print(Modify.inInvi);
    }

}
