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

        public Game()
        {
            finished = false;
            loadMap();
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
            if (curLevel >= levels.Length-1)
            {
                finished = true;
                return;
            }
            curLevel++;

            switchLevels(levels[curLevel], oldLevel);
        }

        public void previousLevel()
        {
            Level oldLevel = levels[curLevel];
            if (curLevel < 1)
            {
                finished = true;
                return;
            }
            curLevel--;

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

        public void update(int frameUpdate)
        {
            getCurrentLevel().updateAllTiles(frameUpdate);
            if (Player.status == EntityStatesEnum.Killed)
                finished = true;
            if (Player.status == EntityStatesEnum.Celebrating)
            {
                Player.status = EntityStatesEnum.Alive;
                Player.Score += (int)getCurrentLevel().getTimeleft();
                nextLevel();
            }
        }
        
        private void loadMap()
        {
            string[] levelsString;
            levelsString = System.IO.Directory.GetFiles("Levels", "*.txt")
                .Select(System.IO.Path.GetFileName)
                .ToArray();
            levels = new Level[levelsString.Length];

            MapLoader mapLoader = new MapLoader();

            foreach (var level in levelsString)
            {
                addLevel(mapLoader.createLevel(level));
            }
        }
    }
}