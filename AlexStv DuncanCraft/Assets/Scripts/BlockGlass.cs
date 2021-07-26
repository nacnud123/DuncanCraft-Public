using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class BlockGlass : Block
{
    public BlockGlass()
        : base()
    {

    }

    public override Tile TexturePosition(Direction direction)
    {
        Tile tile = new Tile();
        tile.x = 4;
        tile.y = 3;
        return tile;
    }

    public override bool IsSolid(Block.Direction direction)
    {
        switch (direction)
        {
            case Direction.east:
                return false;
            case Direction.north:
                return false;
            case Direction.south:
                return false;
            case Direction.west:
                return false;
            case Direction.up:
                return false;
            case Direction.down:
                return false;
        }

        return false;
    }
}