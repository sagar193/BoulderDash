using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Rockford : MovableEntity
    {
        public Rockford(out Tile newTile) : base(out newTile)
        {
        }

        internal override void moveTo(Tile newTile)
        {
            bool canMove = false;

            if (newTile != null)
            {
                if (newTile.entity == null)
                    canMove = true;
                else if (newTile.entity.GetType() == typeof(Exit))
                    canMove = true;
                else if (newTile.entity.GetType() == typeof(FireFly))
                    canMove = true;
                else if (newTile.entity.GetType() == typeof(Mud))
                    canMove = true;
                else
                    canMove = false;
            }
            else
                return;

            if (canMove)
            {
                Tile oldTile = tile;

                oldTile.entity = null;
                newTile.entity = this;
                tile = newTile;
            }
        }

        internal override void react()
        {
            throw new NotImplementedException();
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

            moveTo(possibleNewTile);

            
        }
    }
}