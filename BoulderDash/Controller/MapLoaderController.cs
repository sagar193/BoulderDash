using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Controller
{
    public class MapLoaderController
    {
        public EntityTypesEnum TileEntityTypesEnum;
        private Tile firstTile;
        private Tile lastCreatedTile;
        private Tile firstOfLastRowTile;
        private bool newLine;
        private int columnIterator;
        private int rowIterator;

        public Tile createLevel(string levelPath)
        {
            newLine = false;
            foreach(var line in System.IO.File.ReadAllLines("levels\\"+levelPath))
            {
                foreach(char c in line)
                {
                    switch (c)
                    {
                        case 'S':
                            connectTile(tileEntityFactory(EntityTypesEnum.SteelWall));
                            break;
                        case 'B':
                            connectTile(tileEntityFactory(EntityTypesEnum.Boulder));
                            break;
                        case 'D':
                            connectTile(tileEntityFactory(EntityTypesEnum.Diamond));
                            break;
                        case 'F':
                            connectTile(tileEntityFactory(EntityTypesEnum.Firefly));
                            break;
                        case 'M':
                            connectTile(tileEntityFactory(EntityTypesEnum.Mud));
                            break;
                        case 'R':
                            connectTile(tileEntityFactory(EntityTypesEnum.Rockford));
                            break;
                        case 'W':
                            connectTile(tileEntityFactory(EntityTypesEnum.Wall));
                            break;
                        case ' ':
                            connectTile(tileEntityFactory(EntityTypesEnum.Tile));
                            break;
                        case 'E':
                            connectTile(tileEntityFactory(EntityTypesEnum.Exit));
                            break;
                        default:
                            break;
                    }
                }
                newLine = true;
            }
            return firstTile;
        }

        private Tile tileEntityFactory(EntityTypesEnum type)
        {
            Tile newTileEntity = null;
            switch (type)
            {
                case EntityTypesEnum.Tile:
                    newTileEntity = new Tile();
                    break;
                case EntityTypesEnum.SteelWall:
                    newTileEntity = new Tile(new SteelWall());
                    break;
                case EntityTypesEnum.Exit:
                    newTileEntity = new Tile(new Exit());
                    break;
                case EntityTypesEnum.Wall:
                    newTileEntity = new Tile(new Wall());
                    break;
                case EntityTypesEnum.Mud:
                    newTileEntity = new Tile(new Mud());
                    break;
                case EntityTypesEnum.Boulder:
                    newTileEntity = new Tile(new Boulder());
                    break;
                case EntityTypesEnum.Diamond:
                    newTileEntity = new Tile(new Diamond());
                    break;
                case EntityTypesEnum.Rockford:
                    newTileEntity = new Tile(new Rockford());
                    break;
                case EntityTypesEnum.Firefly:
                    newTileEntity = new Tile(new FireFly());
                    break;
            }

            if (newTileEntity == null)
            {
                throw new Exception();
            }else
            {
                return newTileEntity;
            }
        }

        private void connectTile(Tile newTile)
        {
            ///<summary>Code gets in here with the first TileEntity</summary>
            if (firstTile == null)
            {
                firstTile = newTile;
                lastCreatedTile = newTile;
                firstOfLastRowTile = newTile;

                columnIterator = 0;
            }
            else
            {
                if (newLine == false)
                {
                    lastCreatedTile.Right = newTile;
                    newTile.Left = lastCreatedTile;
                    lastCreatedTile = newTile;

                    columnIterator++;
                    connectUp(newTile);
                } else if (newLine == true)
                {
                    lastCreatedTile = newTile;
                    firstOfLastRowTile = newTile;
                    newLine = false;

                    columnIterator = 0;
                    rowIterator++;
                    connectUp(newTile);
                } else
                {
                    throw new Exception();
                }
            }
        }

        private void connectUp(Tile tile)
        {
            if (rowIterator == 0)
                return;
            Tile upperTile = firstTile;
            for (int i = 0; i < rowIterator -1; i++)
            {
                upperTile = upperTile.Down;
            }
            for (int j = 0; j < columnIterator; j++)
            {
                upperTile = upperTile.Right;
            }
            upperTile.Down = tile;
            tile.Up = upperTile;
        }
    }
}
