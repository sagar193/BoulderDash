using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class InputCMD
    {
        public Queue<System.ConsoleKeyInfo> input;

        public InputCMD()
        {
            input = new Queue<ConsoleKeyInfo>();
        }

        public void waitForInput()
        {
            if (Console.KeyAvailable)
            {
                input.Enqueue(Console.ReadKey(true));
            }
        }
    }
}