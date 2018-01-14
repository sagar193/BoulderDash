using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace BoulderDash
{
    public class Level
    {
        public Tile Tile { get; set; }
        public Rockford rockfordPos { get; set; }
        private DateTime startTime;
        private DateTime stopTime;
        private Timer timer;
        private int levelTime;

        public Level()
        {
            timer = new Timer();
            levelTime = 90;
        }

        public void startTimer()
        {
            timer.Start();

            if (startTime == null)
                startTime = DateTime.Now;
            else
                startTime += (DateTime.Now - stopTime);
        }
        public void stopTimer()
        {
            timer.Stop();
            stopTime = DateTime.Now;
        }
        public double getTimeleft()
        {
            double timeElapsed = (startTime - DateTime.Now).TotalSeconds;
            double timeLeft = levelTime + timeElapsed;
            if (timeLeft < 0)
                rockfordPos.kill();
            return levelTime + timeElapsed;
        }

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