using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockWhiteWool : Block
{

    public BlockWhiteWool()
        : base()
    {
        name = "White Wool";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 0;
        tile.y = 2;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
