using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public abstract class MovableEntity : Entity
    {
        public MovableEntity(out Tile newTile) : base(out newTile)
        {
        }

        internal abstract void moveTo(Tile newTile);
    }
}