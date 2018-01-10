using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class GameController
    {
        private Game Game;
        private InputCMD InputCMD;
        private OutputCMD OutputCMD;
        private Controller.MapLoaderController MapLoaderController;
        private string[] levels;


        public GameController(InputCMD input, OutputCMD output)
        {
            OutputCMD = output;
            InputCMD = input;
            MapLoaderController = new Controller.MapLoaderController();
            Game = new Game();

            loadMap();
            output.showBeginScreen();
            InputCMD.waitForInput();
            OutputCMD.printEntireField();
            InputCMD.waitForInput();

            //bool running = true;
            //while (running)
            //{
            //    Console.WriteLine(input.waitForInput().Key);
            //}
        }

        private void loadMap()
        {
            levels = System.IO.Directory.GetFiles("Levels", "*.txt")
                .Select(System.IO.Path.GetFileName)
                .ToArray();
            Game.TileEntity = MapLoaderController.createLevel(levels[0]);
            OutputCMD.FirstField = Game.TileEntity;
        }
    }
}