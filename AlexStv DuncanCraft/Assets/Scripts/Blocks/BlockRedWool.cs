using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockRedWool : Block
{

    public BlockRedWool()
        : base()
    {
        name = "Red Wool";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 1;
        tile.y = 2;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
