using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockLeaves : Block
{

    public BlockLeaves()
        : base()
    {
        name = "Leaves";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 0;
        tile.y = 1;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
