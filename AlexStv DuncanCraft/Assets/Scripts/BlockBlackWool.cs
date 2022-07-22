using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class BlockBlackWool : Block
{
    public BlockBlackWool()
        : base()
    {
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 1;
        tile.y = 3;
        return tile;
    }

    public override bool IsSolid(Direction direction)
    {
        return false;
    }

}
