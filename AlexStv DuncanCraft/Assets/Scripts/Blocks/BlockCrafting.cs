using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BlockCrafting : Block
{
    //public new bool interactable = true;

    public BlockCrafting()
          : base()
    {
        interactable = true;
        name = "Crafting Table";
    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();

        switch (direction)
        {
            case Direction.up:
                tile.x = 5;
                tile.y = 0;
                return tile;
            case Direction.down:
                tile.x = 3;
                tile.y = 1;
                return tile;
            case Direction.east:
                tile.x = 6;
                tile.y = 0;
                return tile;
            case Direction.west:
                tile.x = 6;
                tile.y = 0;
                return tile;
            case Direction.north:
                tile.x = 7;
                tile.y = 0;
                return tile;
            case Direction.south:
                tile.x = 7;
                tile.y = 0;
                return tile;
        }
        tile.x = 4;
        tile.y = 1;
        return tile;
    }
}
