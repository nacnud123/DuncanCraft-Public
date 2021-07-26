using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public static class Serialization
{
    public static string saveFolderName = "voxelGameSaves";

    public static string SaveLocation(string worldName)
    {
        string saveLocation = saveFolderName + "/" + worldName + "/";

        if (!Directory.Exists(saveLocation))
        {
            Directory.CreateDirectory(saveLocation);
        }

        return saveLocation;
    }

    public static string FileName(WorldPos chunkLocation)
    {
        string fileName = chunkLocation.x + "," + chunkLocation.y + "," + chunkLocation.z + ".bin";
        return fileName;
    }

    public static string seedFile()
    {
        string fileName = "WorldSeedInfo.txt";
        return fileName;
    }


    public static void SaveChunk(Chunk chunk, int yVal)
    {
        Save save = new Save(chunk);
        if (save.blocks.Count == 0)
            return;

        string saveFile = SaveLocation(chunk.world.worldName);
        saveFile += FileName(chunk.pos);

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(saveFile, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, save);
        stream.Close();

    }

    public static int writeSeed(string path, string worldName)
    {
        SaveLocation(worldName);
        int seed = 0;
        path += seedFile();

        FileStream fs = File.Create(path);

        //File.CreateText(path);

        StreamWriter writer = new StreamWriter(fs);

        UnityEngine.Random.seed = System.DateTime.Now.Millisecond;
        seed = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

        writer.WriteLine(seed);
        writer.Close();
        fs.Close();
        return seed;
    }

    public static int readSead(string path)
    {
        int seed = 0;
        path += seedFile();
        StreamReader reader = new StreamReader(path);
        seed = Int32.Parse(reader.ReadToEnd());
        reader.Close();

        return seed;
    }

    public static bool Load(Chunk chunk)
    {
        string saveFile = SaveLocation(chunk.world.worldName);
        saveFile += FileName(chunk.pos);

        if (!File.Exists(saveFile))
            return false;

        IFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(saveFile, FileMode.Open);

        Save save = (Save)formatter.Deserialize(stream);

        foreach (var block in save.blocks)
        {
            chunk.blocks[block.Key.x, block.Key.y, block.Key.z] = block.Value;
        }
        //chunk.randYe = save.seed[0];

        stream.Close();
        return true;
    }
}