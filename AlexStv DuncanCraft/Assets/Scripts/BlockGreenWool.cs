using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockGreenWool : Block
{
    public BlockGreenWool()
        : base()
    {
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 2;
        tile.y = 2;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
