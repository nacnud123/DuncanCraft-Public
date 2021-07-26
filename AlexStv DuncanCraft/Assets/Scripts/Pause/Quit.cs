using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public World world;
    

    public void saveAndQuit()
    {
        var chunksToDelete = new List<WorldPos>();
        foreach (var chunk in world.chunks)
            chunksToDelete.Add(chunk.Key);
        foreach (var chunk in chunksToDelete)
            world.DestroyChunk(chunk.x, chunk.y, chunk.z);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
