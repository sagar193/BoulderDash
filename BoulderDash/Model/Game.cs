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
                    return;
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
            Level oldLevel = levels[curLevel];
            curLevel++;
            if (curLevel >= levels.Length)
            {
                curLevel = 0;
            }

            switchLevels(levels[curLevel], oldLevel);
        }

        public void previousLevel()
        {
            Level oldLevel = levels[curLevel];
            curLevel--;
            if (curLevel < 0)
            {
                curLevel = levels.Length - 1;
            }

            switchLevels(levels[curLevel], oldLevel);
        }

        public void switchLevels(Level newLevel, Level oldLevel)
        {
            Rockford currentRockford = oldLevel.rockfordPos;
            Rockford oldRockford = newLevel.rockfordPos;

            Tile oldTile = Rockford.tile;
            oldRockford.tile.entity = Rockford;
            Rockford.tile = oldRockford.tile;

            oldRockford.tile = oldTile;
            oldTile.entity = oldRockford;

            newLevel.rockfordPos = currentRockford;
            oldLevel.rockfordPos = oldRockford;
        }

        public Tile getCurrentStartTile()
        {
            return levels[curLevel].Tile;
        }
    }
}