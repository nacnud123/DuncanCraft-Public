using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockGoldWool : Block
{
    public BlockGoldWool()
        : base()
    {
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 4;
        tile.y = 2;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
