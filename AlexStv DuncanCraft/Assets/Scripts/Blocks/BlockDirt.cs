using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockDirt : Block
{

    public BlockDirt()
        : base()
    {
        name = "Dirt";
    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        tile.x = 1;
        tile.y = 0;

        return tile;
    }
}