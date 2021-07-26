using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockCoal : Block
{

    public BlockCoal()
        : base()
    {

    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        tile.x = 0;
        tile.y = 3;

        return tile;
    }
}