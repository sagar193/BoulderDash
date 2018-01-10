using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Tile
    {
        public Entity entity;

        public Tile Up { get; set; }
        public Tile Down { get; set; }
        public Tile Left { get; set; }
        public Tile Right { get; set; }

        public Tile(Entity entity)
        {
            this.entity = entity;
        }

        public Tile()
        {
        }
    }
}