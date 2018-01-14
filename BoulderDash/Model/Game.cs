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
        public Rockford Player { get; set; }
        public bool finished { get; set; }

        public Game(int nrOfLevels)
        {
            levels = new Level[nrOfLevels];
            finished = false;
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
            Player = levels[curLevel].rockfordPos;
            getCurrentLevel().startTimer();
        }

        public void nextLevel()
        {
            Level oldLevel = levels[curLevel];
            curLevel++;
            if (curLevel >= levels.Length)
            {
                finished = true;
                return;
            }

            switchLevels(levels[curLevel], oldLevel);
        }

        public void previousLevel()
        {
            Level oldLevel = levels[curLevel];
            curLevel--;
            if (curLevel < 0)
            {
                finished = true;
                return;
            }

            switchLevels(levels[curLevel], oldLevel);
        }

        public void switchLevels(Level newLevel, Level oldLevel)
        {
            oldLevel.stopTimer();
            Rockford currentRockford = oldLevel.rockfordPos;
            Rockford oldRockford = newLevel.rockfordPos;

            Tile oldTile = Player.tile;
            oldRockford.tile.Entity = Player;
            Player.tile = oldRockford.tile;

            oldRockford.tile = oldTile;
            oldTile.Entity = oldRockford;

            newLevel.rockfordPos = currentRockford;
            oldLevel.rockfordPos = oldRockford;
            newLevel.startTimer();
        }

        public Level getCurrentLevel()
        {
            return levels[curLevel];
        }

        public Tile getCurrentStartTile()
        {
            return levels[curLevel].Tile;
        }

        public void update()
        {
            getCurrentLevel().updateAllTiles();
            if (Player.status == EntityStatesEnum.Killed)
                finished = true;
            if (Player.status == EntityStatesEnum.Celebrating)
            {
                Player.status = EntityStatesEnum.Alive;
                Player.Score += (int)getCurrentLevel().getTimeleft();
                nextLevel();
            }
        }


    }
}