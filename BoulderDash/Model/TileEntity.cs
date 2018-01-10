using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public abstract class TileEntity
    {
        public TileEntity Up { get; set; }
        public TileEntity Down { get; set; }
        public TileEntity Left { get; set; }
        public TileEntity Right { get; set; }

        //abstract internal void moveTo(TileEntity newPos);

    }
}