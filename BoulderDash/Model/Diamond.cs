using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Diamond : GravitySensitiveEntity
    {
        public Diamond(out Tile newTile) : base(out newTile)
        {
        }
    }
}