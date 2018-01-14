using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public abstract class StationaryEntity : Entity
    {
        public StationaryEntity(out Tile newTile) : base(out newTile)
        {
        }
    }
}