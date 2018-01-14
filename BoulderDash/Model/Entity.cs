using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public abstract class Entity
    {
        internal Tile tile;
        internal EntityStatesEnum status;
        internal int lastFrameUpdated;

        public Entity(out Tile newTile)
        {
            tile = new Tile(this);
            newTile = tile;
        }

        internal abstract void react(int updateFrame);
    }
}