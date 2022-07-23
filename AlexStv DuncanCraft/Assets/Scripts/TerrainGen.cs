using UnityEngine;
using System.Collections;
using SimplexNoise;

public class TerrainGen
{

    private float stoneBaseHeight = -25;
    private float stoneBaseNoise = 0.05f;
    private float stoneBaseNoiseHeight = 4;

    private float stoneMountainHeight = 48;
    private float stoneMountainFrequency = 0.008f;
    private float stoneMinHeight = -12;

    private float dirtBaseHeight = 5;
    private float dirtNoise = 0.04f;
    private float dirtNoiseHeight = 3;

    private float caveFrequency = 0.025f;
    private int caveSize = 7;

    private float treeFrequency = 0.2f;
    private int treeDensity = 3;

    private float coalSize = 2;
    private float coalFrequency = .01f;

    //bool test = false;


    public Chunk ChunkGen(Chunk chunk, int randY)
    {

        for (int x = chunk.pos.x - 3; x < chunk.pos.x + Chunk.chunkSize + 3; x++)
        {
            for (int z = chunk.pos.z - 3; z < chunk.pos.z + Chunk.chunkSize + 3; z++)
            {
                chunk = ChunkColumnGen(chunk, x, z, randY);
            }
        }
        return chunk;
    }

    public Chunk ChunkColumnGen(Chunk chunk, int x, int z, int randY)
    {

        int stoneHeight = Mathf.FloorToInt(stoneBaseHeight);
        
        stoneHeight += GetNoise(x, randY, z, stoneMountainFrequency, Mathf.FloorToInt(stoneMountainHeight));

        if (stoneHeight < stoneMinHeight)
            stoneHeight = Mathf.FloorToInt(stoneMinHeight);

        stoneHeight += GetNoise(x, randY, z, stoneBaseNoise, Mathf.FloorToInt(stoneBaseNoiseHeight));

        int dirtHeight = stoneHeight + Mathf.FloorToInt(dirtBaseHeight);
        dirtHeight += GetNoise(x, randY, z, dirtNoise, Mathf.FloorToInt(dirtNoiseHeight));

        for (int y = chunk.pos.y - 8; y < chunk.pos.y + Chunk.chunkSize; y++)
        {
            //Get a value to base cave generation on
            int caveChance = GetNoise(x, y, z, caveFrequency, 100);
            int coalChange = GetNoise(x, y, z, coalFrequency, 100);

            if (y <= stoneHeight && caveSize < caveChance)
            {
                SetBlock(x, y, z, new Block(), chunk);
            }
            if(y <= stoneHeight - 10 && coalSize< coalChange)
            {
                SetBlock(x, y, z, new BlockCoal(), chunk);
            }
            else if (y <= dirtHeight && caveSize < caveChance)
            {
                if(y < dirtHeight)
                {
                    SetBlock(x, y, z, new BlockDirt(), chunk);
                }
                else
                {
                    SetBlock(x, y, z, new BlockGrass(), chunk);
                }
                if (y == dirtHeight && GetNoise(x, randY, z, treeFrequency, 100) < treeDensity)
                    CreateTree(x, y + 1, z, chunk);
            }
            else
            {
                SetBlock(x, y, z, new BlockAir(), chunk);
            }

        }

        return chunk;
    }

    public static int GetNoise(int x, int y, int z, float scale, int max)
    {
        return Mathf.FloorToInt((Noise.Generate(x * scale, y * scale, z * scale) + 1f) * (max / 2f));
    }

    public static void SetBlock(int x, int y, int z, Block block, Chunk chunk, bool replaceBlocks = false)
    {
        x -= chunk.pos.x;
        y -= chunk.pos.y;
        z -= chunk.pos.z;
        if (Chunk.InRange(x) && Chunk.InRange(y) && Chunk.InRange(z))
        {
            if (replaceBlocks || chunk.blocks[x, y, z] == null)
                chunk.SetBlock(x, y, z, block);
        }
    }

    void CreateTree(int x, int y, int z, Chunk chunk)
    {
        //create leaves
        for (int xi = -2; xi <= 2; xi++)
        {
            for (int yi = 4; yi <= 8; yi++)
            {
                for (int zi = -2; zi <= 2; zi++)
                {
                    SetBlock(x + xi, y + yi, z + zi, new BlockLeaves(), chunk, true);
                }
            }
        }
        //create trunk
        for (int yt = 0; yt < 6; yt++)
        {
            SetBlock(x, y + yt, z, new BlockWood(), chunk, true);
        }
    }

}