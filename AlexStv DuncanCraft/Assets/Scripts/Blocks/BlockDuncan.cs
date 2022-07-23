using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BlockDuncan : Block
{

    public BlockDuncan()
          : base()
    {
        name = "The Dunc";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 4;
        tile.y = 1;
        return tile;
    }
}
