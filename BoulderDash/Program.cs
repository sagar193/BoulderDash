using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash
{
    class Program
    {
        static void Main(string[] args)
        {
            InputCMD inputView = new InputCMD();
            OutputCMD outputView = new OutputCMD();

            GameController MainGame = new GameController(inputView, outputView);
        }
    }
}
