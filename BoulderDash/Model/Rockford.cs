using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Rockford : MovableEntity
    {
        public int Score { get; set; }

        public Rockford(out Tile newTile) : base(out newTile)
        {
            status = EntityStatesEnum.Alive;
        }
        
        /// <summary>
        /// This function is empty at the moment because Rockfort doesn't react to anything
        /// </summary>
        internal override void react(int updateFrame)
        {
            return;
        }

        

        public void moveInDirection(DirectionEnum direction)
        {
            Tile possibleNewTile = null;

            switch (direction)
            {
                case DirectionEnum.Left:
                    possibleNewTile = tile.Left;
                    break;
                case DirectionEnum.Right:
                    possibleNewTile = tile.Right;
                    break;
                case DirectionEnum.Up:
                    possibleNewTile = tile.Up;
                    break;
                case DirectionEnum.Down:
                    possibleNewTile = tile.Down;
                    break;
                default:
                    break;
            }

            bool canMove = false;

            if (possibleNewTile != null)
            {
                if (possibleNewTile.Entity == null)
                    canMove = true;
                else if (possibleNewTile.getEntityType() == EntityTypesEnum.Exit)
                    status = EntityStatesEnum.Celebrating;
                else if (possibleNewTile.getEntityType() == EntityTypesEnum.Firefly)
                    status = EntityStatesEnum.Killed;
                else if (possibleNewTile.getEntityType() == EntityTypesEnum.Mud)
                    canMove = true;
                else if (possibleNewTile.getEntityType() == EntityTypesEnum.Diamond)
                {
                    canMove = true;
                    Score += 100;
                } else if (possibleNewTile.getEntityType() == EntityTypesEnum.Boulder)
                {
                    Tile targetTile = null;
                    switch (direction)
                    {
                        case DirectionEnum.Left:
                            targetTile = possibleNewTile.Left;
                            break;
                        case DirectionEnum.Right:
                            targetTile = possibleNewTile.Right;
                            break;
                        case DirectionEnum.Up:
                            targetTile = possibleNewTile.Up;
                            break;
                        case DirectionEnum.Down:
                            targetTile = possibleNewTile.Down;
                            break;
                    }
                    if (targetTile != null)
                    {
                        if (targetTile.getEntityType() == EntityTypesEnum.Tile)
                        {
                            targetTile.putOnTile(possibleNewTile.Entity);
                            possibleNewTile.Entity = null;
                            canMove = true;
                        }
                    }
                }
                else
                    canMove = false;
            }
            else
                return;

            if (canMove)
            {
                moveTo(possibleNewTile);
            }
        }

        internal void kill()
        {
            status = EntityStatesEnum.Killed;
        }
    }
}