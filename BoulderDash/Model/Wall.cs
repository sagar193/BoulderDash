using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Wall : StationaryEntity
    {
        public Wall(out Tile newTile) : base(out newTile)
        {
        }

        internal override void react()
        {
            return;
        }
    }
}