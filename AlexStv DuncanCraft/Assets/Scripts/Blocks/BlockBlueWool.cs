using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockBlueWool : Block
{

    public BlockBlueWool()
        : base()
    {
        name = "Blue Wool";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 3;
        tile.y = 2;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
