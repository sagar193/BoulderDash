using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class OutputCMD
    {
        public TileEntity FirstField { get; set; }

        public OutputCMD()
        {
        }

        public void showBeginScreen()
        {
            Console.WriteLine(
                "\n"+
                "╔═════════════════════════╗ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "║                         ║ \n" +
                "╚═════════════════════════╝ \n" +
                " \n" +
                " \n" +
                "Welkom bij boulderdash \n" +
                "Gebruik de pijltjestoetsen om te bewegen"
                );
        }

        public void printEntireField()
        {
            Console.Clear();

            TileEntity lastPrintedField;
            TileEntity firstOfLastLineField;
            bool newLine = false;
            bool lastLine = false;

            findTypeAndPrint(FirstField);
            lastPrintedField = FirstField;
            firstOfLastLineField = FirstField;

            while (lastLine == false)
            {
                if (newLine == true)
                {
                    Console.WriteLine();
                    findTypeAndPrint(firstOfLastLineField.Down);
                    lastPrintedField = firstOfLastLineField.Down;
                    firstOfLastLineField = lastPrintedField;
                }
                while (lastPrintedField.Right != null)
                {
                    findTypeAndPrint(lastPrintedField.Right);
                    lastPrintedField = lastPrintedField.Right;
                }
                if (firstOfLastLineField.Down != null)
                    newLine = true;
                else
                    lastLine = true;

            }
            
        }

        private void findTypeAndPrint(TileEntity tileEntity)
        {
            TileEntityTypesEnum printingType;

            if (tileEntity.GetType() == typeof(SteelWall))
                printingType = TileEntityTypesEnum.SteelWall;
            else if (tileEntity.GetType() == typeof(Boulder))
                printingType = TileEntityTypesEnum.Boulder;
            else if (tileEntity.GetType() == typeof(Diamond))
                printingType = TileEntityTypesEnum.Diamond;
            else if (tileEntity.GetType() == typeof(EmptyTile))
                printingType = TileEntityTypesEnum.EmptyTile;
            else if (tileEntity.GetType() == typeof(Exit))
                printingType = TileEntityTypesEnum.Exit;
            else if (tileEntity.GetType() == typeof(FireFly))
                printingType = TileEntityTypesEnum.Firefly;
            else if (tileEntity.GetType() == typeof(Mud))
                printingType = TileEntityTypesEnum.Mud;
            else if (tileEntity.GetType() == typeof(Rockford))
                printingType = TileEntityTypesEnum.Rockford;
            else if (tileEntity.GetType() == typeof(Wall))
                printingType = TileEntityTypesEnum.Wall;
            else
                throw new Exception();

            switch (printingType)
            {
                case TileEntityTypesEnum.EmptyTile:
                    Console.Write(" ");
                    break;
                case TileEntityTypesEnum.SteelWall:
                    printSteelWall(tileEntity);
                    break;
                case TileEntityTypesEnum.Exit:
                    Console.Write("E");
                    break;
                case TileEntityTypesEnum.Wall:
                    Console.Write("=");
                    break;
                case TileEntityTypesEnum.Mud:
                    Console.Write("▒");
                    break;
                case TileEntityTypesEnum.Boulder:
                    Console.Write("B");
                    break;
                case TileEntityTypesEnum.Diamond:
                    Console.Write("¤");
                    break;
                case TileEntityTypesEnum.Rockford:
                    Console.Write("©");
                    break;
                case TileEntityTypesEnum.Firefly:
                    Console.Write("F");
                    break;
            }
        }

        public void printSteelWall(TileEntity tileEntity)
        {
            bool upIsSteelWall = false;
            bool downIsSteelWall = false;
            bool rightIsSteelWall = false;
            bool leftIsSteelWall = false;

            if(tileEntity.Up != null)
            {
                if (tileEntity.Up.GetType() == typeof(SteelWall))
                    upIsSteelWall = true;
            }
            if (tileEntity.Down != null)
            {
                if (tileEntity.Down.GetType() == typeof(SteelWall))
                    downIsSteelWall = true;
            }
            if (tileEntity.Right != null)
            {
                if (tileEntity.Right.GetType() == typeof(SteelWall))
                    rightIsSteelWall = true;
            }
            if (tileEntity.Left != null)
            {
                if (tileEntity.Left.GetType() == typeof(SteelWall))
                    leftIsSteelWall = true;
            }

            if (upIsSteelWall && downIsSteelWall && rightIsSteelWall && leftIsSteelWall)
                Console.Write("╬");
            else if (upIsSteelWall && downIsSteelWall && rightIsSteelWall)
                Console.Write("╠");
            else if (upIsSteelWall && downIsSteelWall && leftIsSteelWall)
                Console.Write("╣");
            else if (downIsSteelWall && rightIsSteelWall && leftIsSteelWall)
                Console.Write("╦");
            else if (upIsSteelWall && rightIsSteelWall && leftIsSteelWall)
                Console.Write("╩");
            else if (downIsSteelWall && rightIsSteelWall)
                Console.Write("╔");
            else if (upIsSteelWall && downIsSteelWall)
                Console.Write("║");
            else if (rightIsSteelWall && upIsSteelWall)
                Console.Write("╚");
            else if (rightIsSteelWall && leftIsSteelWall)
                Console.Write("═");
            else if (leftIsSteelWall && upIsSteelWall)
                Console.Write("╝");
            else if (leftIsSteelWall && downIsSteelWall)
                Console.Write("╗");
            else
                throw new Exception();
        }
        
    }
}