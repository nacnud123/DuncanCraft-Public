using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BlockPlank : Block
{

    public BlockPlank()
          : base()
    {
        name = "Planks";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 3;
        tile.y = 1;
        return tile;
    }
}
