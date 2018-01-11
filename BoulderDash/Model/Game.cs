using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Game
    {
        Level[] levels;
        int curLevel;
        public Rockford Rockford { get; set; }
        public FireFly[] FireFly;

        public Game(int nrOfLevels)
        {
            levels = new Level[nrOfLevels];
        }

        public void addLevel(Level newLevel)
        {
            for (int i = 0; i < levels.Length; i++)
            {
                if (levels[i] == null)
                {
                    levels[i] = newLevel;
                }
            }
        }

        public void start()
        {
            curLevel = 0;
            Rockford = levels[curLevel].rockfordPos;
        }

        public void nextLevel()
        {
            curLevel++;
            if (curLevel > levels.Length)
            {
                throw new Exception("No next level available");
            }

            Rockford oldRockford = levels[curLevel].rockfordPos;
            oldRockford.tile.entity = Rockford;
            Rockford.tile = oldRockford.tile;

            oldRockford.tile = null; //bye rockford :(
        }

        public Tile getCurrentStartTile()
        {
            return levels[curLevel].Tile;
        }
    }
}