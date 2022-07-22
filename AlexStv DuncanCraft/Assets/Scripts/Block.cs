using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Block
{
    public enum Direction { north, east, south, west, up, down, northEast, northWest };

    public struct Tile { public int x; public int y; }
    const float tileSize = 0.125f;
    public bool changed = true;

    float slabHeight = -.05f;

    //Base block constructor
    public Block()
    {

    }

    public virtual MeshData Blockdata
     (Chunk chunk, int x, int y, int z, MeshData meshData)
    {

        meshData.useRenderDataForCol = true;

        if (!chunk.GetBlock(x, y + 1, z).IsSolid(Direction.down))
        {
            meshData = FaceDataUp(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y - 1, z).IsSolid(Direction.up))
        {
            meshData = FaceDataDown(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y, z + 1).IsSolid(Direction.south))
        {
            meshData = FaceDataNorth(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x, y, z - 1).IsSolid(Direction.north))
        {
            meshData = FaceDataSouth(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x + 1, y, z).IsSolid(Direction.west))
        {
            meshData = FaceDataEast(chunk, x, y, z, meshData);
        }

        if (!chunk.GetBlock(x - 1, y, z).IsSolid(Direction.east))
        {
            meshData = FaceDataWest(chunk, x, y, z, meshData);
        }

        return meshData;

    }

    protected virtual MeshData FaceDataUp
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.up));
        return meshData;
    }

    protected virtual MeshData FaceDataDown
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.down));
        return meshData;
    }

    protected virtual MeshData FaceDataNorth
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.north));
        return meshData;
    }

    protected virtual MeshData FaceDataEast
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.east));
        return meshData;
    }

    protected virtual MeshData FaceDataSouth
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.south));
        return meshData;
    }


    protected virtual MeshData FaceDataWest
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.west));
        return meshData;
    }

    //Flowers / cross blocks

    protected virtual MeshData CrossDataLeft
      (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f)); // bottom Left
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f)); // Top left corner
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f)); // top right corner
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f)); // Bottom Right

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.northEast));
        return meshData;
    }

    protected virtual MeshData CrossDataRight
       (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f)); // bottom Left
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f)); // Top left corner
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f)); // top right corner
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f)); // Bottom Right

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.northWest));
        return meshData;
    }


    protected virtual MeshData CrossDataBack
      (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f)); // bottom Left
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z - 0.5f)); // Top left corner
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z + 0.5f)); // top right corner
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f)); // Bottom Right

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.northEast));
        return meshData;
    }

    protected virtual MeshData CrossDataFront
       (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f)); // bottom Left
        meshData.AddVertex(new Vector3(x + 0.5f, y + 0.5f, z + 0.5f)); // Top left corner
        meshData.AddVertex(new Vector3(x - 0.5f, y + 0.5f, z - 0.5f)); // top right corner
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f)); // Bottom Right

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.northWest));
        return meshData;
    }

    protected virtual MeshData CrossDataBottom
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.3f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.3f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.3f, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.3f, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.up));
        return meshData;
    }

    protected virtual MeshData FaceDataEastHalf // Half
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.east));
        return meshData;
    }

    protected virtual MeshData FaceDataWestHalf // Half
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.west));
        return meshData;
    }

    protected virtual MeshData FaceDataNorthHalf // Half
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z + 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.north));
        return meshData;
    }

    protected virtual MeshData FaceDataSouthHalf // Half
       (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - 0.5f, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - 0.5f, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.south));
        return meshData;
    }

    protected virtual MeshData FaceDataUpHalf // Half
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y + slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y + slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y + slabHeight, z - 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.up));
        return meshData;
    }

    protected virtual MeshData FaceDataDownHalf // Half
        (Chunk chunk, int x, int y, int z, MeshData meshData)
    {
        meshData.AddVertex(new Vector3(x - 0.5f, y - slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - slabHeight, z - 0.5f));
        meshData.AddVertex(new Vector3(x + 0.5f, y - slabHeight, z + 0.5f));
        meshData.AddVertex(new Vector3(x - 0.5f, y - slabHeight, z + 0.5f));

        meshData.AddQuadTriangles();
        meshData.uv.AddRange(FaceUVs(Direction.down));
        return meshData;
    }


    



    public virtual Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 0;
        tile.y = 0;

        return tile;
    }

    public virtual Vector2[] FaceUVs(Direction direction)
    {
        Vector2[] UVs = new Vector2[4];
        Tile tilePos = TexturePosition(direction);
        UVs[0] = new Vector2(tileSize * tilePos.x + tileSize, tileSize * tilePos.y);
        UVs[1] = new Vector2(tileSize * tilePos.x + tileSize, tileSize * tilePos.y + tileSize);
        UVs[2] = new Vector2(tileSize * tilePos.x, tileSize * tilePos.y + tileSize);
        UVs[3] = new Vector2(tileSize * tilePos.x, tileSize * tilePos.y);
        return UVs;
    }

    public virtual bool IsSolid(Direction direction)
    {
        switch (direction)
        {
            case Direction.north:
                return true;
            case Direction.east:
                return true;
            case Direction.south:
                return true;
            case Direction.west:
                return true;
            case Direction.up:
                return true;
            case Direction.down:
                return true;
        }

        return false;
    }

}