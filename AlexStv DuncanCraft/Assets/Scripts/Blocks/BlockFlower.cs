using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockFlower : Block
{

    public BlockFlower()
        : base()
    {
        name = "Flower";
    }

    public override MeshData Blockdata
       (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        //meshData.useRenderDataForCol = false;
        

        if (!chunk.GetBlock(x, y, z + 1).IsSolid(Direction.northEast))
        {
            meshData = CrossDataLeft(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y, z - 1).IsSolid(Direction.northWest))
        {
            meshData = CrossDataRight(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x + 1, y, z).IsSolid(Direction.northWest))
        {
            meshData = CrossDataFront(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x - 1, y, z).IsSolid(Direction.northEast))
        {
            meshData = CrossDataBack(chunk, x, y, z, meshData);
        }


        return meshData;
    }


    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        switch (direction)
        {
            case Direction.northEast:
                tile.x = 0;
                tile.y = 4;
                return tile;
            case Direction.northWest:
                tile.x = 0;
                tile.y = 4;
                return tile;
        }
        tile.x = 0;
        tile.y = 4;
        return tile;
    }

    public override bool IsSolid(Block.Direction direction)
    {
        switch (direction)
        {
            case Direction.northWest:
                return true;
            case Direction.northEast:
                return true;
            case Direction.east:
                return false;
            case Direction.north:
                return false;
            case Direction.south:
                return false;
            case Direction.west:
                return false;
            case Direction.up:
                return false;
            case Direction.down:
                return false;
        }

        return false;
    }
}