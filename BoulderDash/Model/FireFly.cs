﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class FireFly : MovableEntity
    {
        public FireFly(out Tile newTile) : base(out newTile)
        {
        }

        internal override void moveTo(Tile newTile)
        {
            throw new NotImplementedException();
        }

        internal override void react()
        {
            throw new NotImplementedException();
        }
    }
}