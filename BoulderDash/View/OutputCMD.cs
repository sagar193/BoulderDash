using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class OutputCMD
    {
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

        public void printField(Tile firstTile)
        {
            Console.Clear();

            Tile lastPrintedField;
            Tile firstOfLastLineField;
            bool newLine = false;
            bool lastLine = false;

            findTypeAndPrint(firstTile);
            lastPrintedField = firstTile;
            firstOfLastLineField = firstTile;

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

        private void findTypeAndPrint(Tile tile)
        {
            EntityTypesEnum printingType;
            if (tile.entity == null)
                printingType = EntityTypesEnum.Tile;
            else if (tile.entity.GetType() == typeof(SteelWall))
                printingType = EntityTypesEnum.SteelWall;
            else if (tile.entity.GetType() == typeof(Boulder))
                printingType = EntityTypesEnum.Boulder;
            else if (tile.entity.GetType() == typeof(Diamond))
                printingType = EntityTypesEnum.Diamond;
            else if (tile.entity.GetType() == typeof(Exit))
                printingType = EntityTypesEnum.Exit;
            else if (tile.entity.GetType() == typeof(FireFly))
                printingType = EntityTypesEnum.Firefly;
            else if (tile.entity.GetType() == typeof(Mud))
                printingType = EntityTypesEnum.Mud;
            else if (tile.entity.GetType() == typeof(Rockford))
                printingType = EntityTypesEnum.Rockford;
            else if (tile.entity.GetType() == typeof(Wall))
                printingType = EntityTypesEnum.Wall;
            else
                throw new Exception();

            switch (printingType)
            {
                case EntityTypesEnum.Tile:
                    Console.Write(" ");
                    break;
                case EntityTypesEnum.SteelWall:
                    printSteelWall(tile);
                    break;
                case EntityTypesEnum.Exit:
                    Console.Write("E");
                    break;
                case EntityTypesEnum.Wall:
                    Console.Write("=");
                    break;
                case EntityTypesEnum.Mud:
                    Console.Write("▒");
                    break;
                case EntityTypesEnum.Boulder:
                    Console.Write("B");
                    break;
                case EntityTypesEnum.Diamond:
                    Console.Write("¤");
                    break;
                case EntityTypesEnum.Rockford:
                    Console.Write("©");
                    break;
                case EntityTypesEnum.Firefly:
                    Console.Write("F");
                    break;
            }
        }

        private void printSteelWall(Tile tile)
        {
            bool upIsSteelWall = false;
            bool downIsSteelWall = false;
            bool rightIsSteelWall = false;
            bool leftIsSteelWall = false;

            if(tile.Up != null && tile.Up.entity != null)
            {
                if (tile.Up.entity.GetType() == typeof(SteelWall))
                    upIsSteelWall = true;
            }
            if (tile.Down != null && tile.Down.entity != null)
            {
                if (tile.Down.entity.GetType() == typeof(SteelWall))
                    downIsSteelWall = true;
            }
            if (tile.Right != null && tile.Right.entity != null)
            {
                if (tile.Right.entity.GetType() == typeof(SteelWall))
                    rightIsSteelWall = true;
            }
            if (tile.Left != null && tile.Left.entity != null)
            {
                if (tile.Left.entity.GetType() == typeof(SteelWall))
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
            else if (downIsSteelWall)
                Console.Write("╥");
            else
                throw new Exception("unprogrammed steel wall");
        }

        public void printSpecific(string x)
        {
            Console.WriteLine(x);
        }
        
    }
}