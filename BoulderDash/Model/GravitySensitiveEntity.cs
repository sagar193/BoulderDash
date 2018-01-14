using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public abstract class GravitySensitiveEntity : MovableEntity
    {

        public GravitySensitiveEntity(out Tile newTile) : base(out newTile)
        {
            interval = 1;
            lastInterval = 0;
            status = EntityStatesEnum.Idle;
        }


        internal override void react(int updateFrame)
        {
            if (lastFrameUpdated == updateFrame)
                return;
            else
                lastFrameUpdated = updateFrame;

            if (lastInterval == interval)
            {
                if (status == EntityStatesEnum.Idle)
                {
                    if (tile.Down != null && tile.Down.getEntityType() == EntityTypesEnum.Tile)
                    {
                        moveTo(tile.Down);
                        status = EntityStatesEnum.Falling;
                        lastInterval = 0;
                    }
                    else if (
                      tile.Down != null && tile.Left != null && tile.Down.Left != null &&
                      tile.Down.getEntityType() == EntityTypesEnum.Boulder &&
                      tile.Left.getEntityType() == EntityTypesEnum.Tile &&
                      tile.Down.Left.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Down != null && tile.Left != null && tile.Down.Left != null &&
                      tile.Down.getEntityType() == EntityTypesEnum.Diamond &&
                      tile.Left.getEntityType() == EntityTypesEnum.Tile &&
                      tile.Down.Left.getEntityType() == EntityTypesEnum.Tile)
                    {
                        moveTo(tile.Down.Left);
                        status = EntityStatesEnum.Falling;
                        lastInterval = 0;
                    }
                    else if (
                      tile.Down != null && tile.Right != null && tile.Down.Right != null &&
                      tile.Down.getEntityType() == EntityTypesEnum.Boulder &&
                      tile.Right.getEntityType() == EntityTypesEnum.Tile &&
                      tile.Down.Right.getEntityType() == EntityTypesEnum.Tile ||
                      tile.Down != null && tile.Right != null && tile.Down.Right != null &&
                      tile.Down.getEntityType() == EntityTypesEnum.Diamond &&
                      tile.Right.getEntityType() == EntityTypesEnum.Tile &&
                      tile.Down.Right.getEntityType() == EntityTypesEnum.Tile
                      )
                    {
                        moveTo(tile.Down.Right);
                        status = EntityStatesEnum.Falling;
                        lastInterval = 0;
                    }
                }
                else if (status == EntityStatesEnum.Falling)
                {
                    if (tile.Down != null && tile.Down.getEntityType() == EntityTypesEnum.Tile)
                    {
                        moveTo(tile.Down);
                        status = EntityStatesEnum.Falling;
                        lastInterval = 0;
                    }
                    else if (tile.Down != null && tile.Down.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        Rockford rf = tile.Down.Entity as Rockford;
                        rf.kill();
                    }
                    else if (
                        tile.Down != null && tile.Left != null && tile.Down.Left != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Boulder &&
                        tile.Left.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Left.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Down != null && tile.Left != null && tile.Down.Left != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Diamond &&
                        tile.Left.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Left.getEntityType() == EntityTypesEnum.Tile)
                    {
                        moveTo(tile.Down.Left);
                        status = EntityStatesEnum.Falling;
                        lastInterval = 0;
                    }
                    else if (
                        tile.Down != null && tile.Left != null && tile.Down.Left != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Boulder &&
                        tile.Left.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Left.getEntityType() == EntityTypesEnum.Rockford ||
                        tile.Down != null && tile.Left != null && tile.Down.Left != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Diamond &&
                        tile.Left.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Left.getEntityType() == EntityTypesEnum.Rockford)
                    {
                        Rockford rf = tile.Down.Entity as Rockford;
                        rf.kill();
                    }
                    else if (
                        tile.Down != null && tile.Right != null && tile.Down.Right != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Boulder &&
                        tile.Right.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Right.getEntityType() == EntityTypesEnum.Tile ||
                        tile.Down != null && tile.Right != null && tile.Down.Right != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Diamond &&
                        tile.Right.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Right.getEntityType() == EntityTypesEnum.Tile
                      )
                    {
                        moveTo(tile.Down.Right);
                        status = EntityStatesEnum.Falling;
                        lastInterval = 0;
                    }
                    else if (
                        tile.Down != null && tile.Right != null && tile.Down.Right != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Boulder &&
                        tile.Right.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Right.getEntityType() == EntityTypesEnum.Rockford ||
                        tile.Down != null && tile.Right != null && tile.Down.Right != null &&
                        tile.Down.getEntityType() == EntityTypesEnum.Diamond &&
                        tile.Right.getEntityType() == EntityTypesEnum.Tile &&
                        tile.Down.Right.getEntityType() == EntityTypesEnum.Rockford
                     )
                    {
                        Rockford rf = tile.Down.Entity as Rockford;
                        rf.kill();
                    }
                    else
                    {
                        status = EntityStatesEnum.Idle;
                    }
                }
            }
            else
            {
                lastInterval++;
            }

        }
    }
}