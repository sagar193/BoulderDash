using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Level
    {
        public Tile Tile { get; set; }
        public Rockford rockfordPos { get; set; }

        public void updateAllTiles()
        {
            Tile beginUpdateTile = Tile;
            Tile firstTileInRow = Tile;

            Tile.Entity.react();

            while (firstTileInRow.Down != null)
            {
                if (beginUpdateTile.Right.Entity != null)
                    beginUpdateTile.Right.Entity.react();
                beginUpdateTile = beginUpdateTile.Right;
                
                if(beginUpdateTile.Right == null)
                {
                    if (firstTileInRow.Down != null)
                    {
                        firstTileInRow = firstTileInRow.Down;
                        beginUpdateTile = firstTileInRow;
                        firstTileInRow.Entity.react();
                    }
                }
            }
        }
    }
}