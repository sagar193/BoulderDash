using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class FireFly : MovableEntity
    {
        DirectionEnum lastMovedDirection;
        public FireFly(out Tile newTile) : base(out newTile)
        {
            interval = 1;
            lastInterval = 0;
            lastMovedDirection = DirectionEnum.Up;
        }

        internal override void react()
        {
        if (lastInterval == interval)
            {
                lastInterval = 0;
                #region lastMovedLeft is left (down left up)
                if (lastMovedDirection == DirectionEnum.Left)
                {
                    if (tile.Down.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Down.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Down);
                        lastMovedDirection = DirectionEnum.Down;
                        return;
                    } else if (tile.Left.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Left.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Left);
                        lastMovedDirection = DirectionEnum.Left;
                        return;
                    } else if (tile.Up.getEntityType() == EntityTypesEnum.Tile||
                        tile.Up.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Up);
                        lastMovedDirection = DirectionEnum.Up;
                        return;
                    } else
                    {
                        lastMovedDirection = DirectionEnum.Up;
                        return;
                    }
                }
                #endregion
                #region lastMovedDirection  is Down (right down left)
                else if (lastMovedDirection == DirectionEnum.Down)
                {
                    if (tile.Right.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Right.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Right);
                        lastMovedDirection = DirectionEnum.Right;
                        return;
                    }
                    else if (tile.Down.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Down.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Down);
                        lastMovedDirection = DirectionEnum.Down;
                        return;
                    }
                    else if (tile.Left.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Left.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Left);
                        lastMovedDirection = DirectionEnum.Left;
                        return;
                    }
                    else
                    {
                        lastMovedDirection = DirectionEnum.Left;
                        return;
                    }
                }
                #endregion
                #region lastMovedDirection  is Up (left up right)
                else if (lastMovedDirection == DirectionEnum.Up)
                {
                    if (tile.Left.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Left.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Left);
                        lastMovedDirection = DirectionEnum.Left;
                        return;
                    }
                    else if (tile.Up.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Up.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Up);
                        lastMovedDirection = DirectionEnum.Up;
                        return;
                    }
                    else if (tile.Right.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Right.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Right);
                        lastMovedDirection = DirectionEnum.Right;
                        return;
                    }
                    else
                    {
                        lastMovedDirection = DirectionEnum.Right;
                        return;
                    }
                }
                #endregion
                #region lastMovedDirection  is Right (up right down)
                else if (lastMovedDirection == DirectionEnum.Right)
                {
                    if (tile.Up.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Up.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Up);
                        lastMovedDirection = DirectionEnum.Up;
                        return;
                    }
                    else if (tile.Right.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Right.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Right);
                        lastMovedDirection = DirectionEnum.Right;
                        return;
                    }
                    else if (tile.Down.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Down.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        moveOrKill(tile.Down);
                        lastMovedDirection = DirectionEnum.Down;
                        return;
                    }
                    else
                    {
                        lastMovedDirection = DirectionEnum.Down;
                        return;
                    }
                }
                #endregion

            }
            else
            {
                lastInterval++;
            }

        }
        
        void moveOrKill(Tile tile)
        {
            if (tile.getEntityType() == EntityTypesEnum.Tile)
            {
                moveTo(tile);
            } else if (tile.getEntityType() == EntityTypesEnum.Rockford)
            {
                Rockford rf = tile.Entity as Rockford;
                rf.kill();
            }
        }
    }
}