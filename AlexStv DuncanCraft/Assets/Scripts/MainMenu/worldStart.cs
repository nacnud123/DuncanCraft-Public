using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class worldStart : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public WorldName worldNameGameObject;
    public void getInput()
    {
        var input = gameObject.transform.parent.GetChild(2).GetComponent<TMP_InputField>();
        print(input.text);
        worldNameGameObject.worldName = input.text;
        worldNameGameObject.Gamer();
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }

    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

}
