using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoulderDash.Controller
{
    public class MapLoaderController
    {
        public TileEntityTypesEnum TileEntityTypesEnum;
        private TileEntity firstTileEntity;
        private TileEntity lastCreatedTileEntity;
        private TileEntity firstOfLastRowTileEntity;
        private bool newLine;
        private int columnIterator;
        private int rowIterator;

        public TileEntity createLevel(string levelPath)
        {
            newLine = false;
            foreach(var line in System.IO.File.ReadAllLines("levels\\"+levelPath))
            {
                foreach(char c in line)
                {
                    switch (c)
                    {
                        case 'S':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.SteelWall));
                            break;
                        case 'B':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Boulder));
                            break;
                        case 'D':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Diamond));
                            break;
                        case 'F':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Firefly));
                            break;
                        case 'M':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Mud));
                            break;
                        case 'R':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Rockford));
                            break;
                        case 'W':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Wall));
                            break;
                        case ' ':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.EmptyTile));
                            break;
                        case 'E':
                            connectTileEntity(tileEntityFactory(TileEntityTypesEnum.Exit));
                            break;
                        default:
                            break;
                    }
                }
                newLine = true;
            }
            return firstTileEntity;
        }

        private TileEntity tileEntityFactory(TileEntityTypesEnum type)
        {
            TileEntity newTileEntity = null;
            switch (type)
            {
                case TileEntityTypesEnum.EmptyTile:
                    newTileEntity = new EmptyTile();
                    break;
                case TileEntityTypesEnum.SteelWall:
                    newTileEntity = new SteelWall();
                    break;
                case TileEntityTypesEnum.Exit:
                    newTileEntity = new Exit();
                    break;
                case TileEntityTypesEnum.Wall:
                    newTileEntity = new Wall();
                    break;
                case TileEntityTypesEnum.Mud:
                    newTileEntity = new Mud();
                    break;
                case TileEntityTypesEnum.Boulder:
                    newTileEntity = new Boulder();
                    break;
                case TileEntityTypesEnum.Diamond:
                    newTileEntity = new Diamond();
                    break;
                case TileEntityTypesEnum.Rockford:
                    newTileEntity = new Rockford();
                    break;
                case TileEntityTypesEnum.Firefly:
                    newTileEntity = new FireFly();
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

        private void connectTileEntity(TileEntity newTileEntity)
        {
            ///<summary>Code gets in here with the first TileEntity</summary>
            if (firstTileEntity == null)
            {
                firstTileEntity = newTileEntity;
                lastCreatedTileEntity = newTileEntity;
                firstOfLastRowTileEntity = newTileEntity;

                columnIterator = 0;
            }
            else
            {
                if (newLine == false)
                {
                    lastCreatedTileEntity.Right = newTileEntity;
                    newTileEntity.Left = lastCreatedTileEntity;
                    lastCreatedTileEntity = newTileEntity;

                    columnIterator++;
                    connectUp(newTileEntity);
                } else if (newLine == true)
                {
                    lastCreatedTileEntity = newTileEntity;
                    firstOfLastRowTileEntity = newTileEntity;
                    newLine = false;

                    columnIterator = 0;
                    rowIterator++;
                    connectUp(newTileEntity);
                } else
                {
                    throw new Exception();
                }
            }
        }

        private void connectUp(TileEntity tileEntity)
        {
            if (rowIterator == 0)
                return;
            TileEntity upperTileEntity = firstTileEntity;
            for (int i = 0; i < rowIterator -1; i++)
            {
                upperTileEntity = upperTileEntity.Down;
            }
            for (int j = 0; j < columnIterator; j++)
            {
                upperTileEntity = upperTileEntity.Right;
            }
            upperTileEntity.Down = tileEntity;
            tileEntity.Up = upperTileEntity;
        }
    }
}
