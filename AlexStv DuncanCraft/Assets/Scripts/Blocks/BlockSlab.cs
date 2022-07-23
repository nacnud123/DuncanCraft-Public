using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockSlab : Block
{

    public BlockSlab()
        : base()
    {
        name = "Slab";
    }

    public override MeshData Blockdata(Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.useRenderDataForCol = true;


        if (!chunk.GetBlock(x, y + 1, z).IsSolid(Direction.down))
        {
            meshData = FaceDataUpHalf(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y - 1, z).IsSolid(Direction.up))
        {
            meshData = FaceDataDown(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y, z + 1).IsSolid(Direction.south))
        {
            meshData = FaceDataNorthHalf(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y, z - 1).IsSolid(Direction.north))
        {
            meshData = FaceDataSouthHalf(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x + 1, y, z).IsSolid(Direction.west))
        {
            meshData = FaceDataEastHalf(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x - 1, y, z).IsSolid(Direction.east))
        {
            meshData = FaceDataWestHalf(chunk, x, y, z, meshData);
        }

        return meshData;
    }


    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        switch (direction)
        {
            case Direction.northEast:
                tile.x = 3;
                tile.y = 1;
                return tile;
            case Direction.northWest:
                tile.x = 3;
                tile.y = 1;
                return tile;
        }
        tile.x = 3;
        tile.y = 1;
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