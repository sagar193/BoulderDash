﻿using System;
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

        public void printScoreTime(double time, int score)
        {
            Console.WriteLine("time left: " + (int)time + "              score: " + score);
        }

        public void printField(Tile firstTile)
        {
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

        public void clearScreen()
        {
            Console.Clear();
        }

        private void findTypeAndPrint(Tile tile)
        {
            EntityTypesEnum printingType = tile.getEntityType();

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

        internal void printEndScreen(int score)
        {
            Console.WriteLine("Game Over");
            Console.WriteLine("Total score: " + score);
            Console.WriteLine("Press any key to exit the game");
        }

        private void printSteelWall(Tile tile)
        {
            bool upIsSteelWall = false;
            bool downIsSteelWall = false;
            bool rightIsSteelWall = false;
            bool leftIsSteelWall = false;

            if(tile.Up != null)
            {
                if (tile.Up.getEntityType() == EntityTypesEnum.SteelWall)
                    upIsSteelWall = true;
            }
            if (tile.Down != null)
            {
                if (tile.Down.getEntityType() == EntityTypesEnum.SteelWall)
                    downIsSteelWall = true;
            }
            if (tile.Right != null)
            {
                if (tile.Right.getEntityType() == EntityTypesEnum.SteelWall)
                    rightIsSteelWall = true;
            }
            if (tile.Left != null)
            {
                if (tile.Left.getEntityType() == EntityTypesEnum.SteelWall)
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