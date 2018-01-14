using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Boulder : GravitySensitiveEntity
    {
        public Boulder(out Tile newTile) : base(out newTile)
        {
            status = EntityStatesEnum.Idle;
        }


        
    }
}