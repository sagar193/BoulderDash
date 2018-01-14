using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class InputCMD
    {
        private Queue<System.ConsoleKeyInfo> input;

        public InputCMD()
        {
            input = new Queue<ConsoleKeyInfo>();
        }

        public void queueInput()
        {
            if (Console.KeyAvailable)
            {
                input.Enqueue(Console.ReadKey(true));
            }
        }

        public void waitForInput()
        {
            Console.ReadKey();
        }

        public ConsoleKeyInfo getInputFromQueue()
        {
            return input.Dequeue();
        }
    }
}