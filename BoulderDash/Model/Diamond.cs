﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Diamond : MovableEntity
    {
        public Diamond(out Tile newTile) : base(out newTile)
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