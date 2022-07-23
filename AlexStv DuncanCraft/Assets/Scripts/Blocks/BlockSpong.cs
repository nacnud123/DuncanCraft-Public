using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BlockSpong : Block
{

    public BlockSpong()
          : base()
    {
        name = "Sponge";
    }
    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 4;
        tile.y = 0;
        return tile;
    }
}
