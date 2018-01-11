﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class GameController
    {
        /// <summary> nrOfFPSConstant should be the number of frames you want</summary>
        const int nrOfFPSConstant = 5;

        private Game game;
        private InputCMD inputCMD;
        private OutputCMD outputCMD;
        private Controller.MapLoaderController mapLoaderController;
        private string[] levels;
        int fps = 1000 / nrOfFPSConstant;


        public GameController(InputCMD input, OutputCMD output)
        {
            outputCMD = output;
            inputCMD = input;
            mapLoaderController = new Controller.MapLoaderController();

            loadMap();
            output.showBeginScreen();
            inputCMD.waitForInput();

            game.start();

            bool running = true;
            while (running)
            {
                if (Console.KeyAvailable)
                {
                    inputCMD.waitForInput();
                    ConsoleKeyInfo key = inputCMD.input.Dequeue();
                    if (key != null)
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.F1:
                                Console.WriteLine("You pressed F1!");
                                break;
                            case ConsoleKey.Add:
                                game.nextLevel();
                                break;
                            case ConsoleKey.Subtract:
                                game.previousLevel();
                                break;
                            default:
                                break;
                        }
                    }
                }
                outputCMD.printField(game.getCurrentStartTile());

                System.Threading.Thread.Sleep(fps);
            }
        }

        private void loadMap()
        {
            levels = System.IO.Directory.GetFiles("Levels", "*.txt")
                .Select(System.IO.Path.GetFileName)
                .ToArray();
            game = new Game(levels.Length);

            foreach (var level in levels)
            {
                game.addLevel(mapLoaderController.createLevel(level));
            }
        }
    }
}