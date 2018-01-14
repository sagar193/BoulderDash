using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public abstract class MovableEntity : Entity
    {
        protected int interval;
        protected int lastInterval;

        public MovableEntity(out Tile newTile) : base(out newTile)
        {
        }

        internal void moveTo(Tile newTile)
        {
            Tile oldTile = tile;

            oldTile.Entity = null;
            newTile.Entity = this;
            tile = newTile;
        }

        
        internal bool moveOrKill(Tile tile)
        {
            if (tile.getEntityType() == EntityTypesEnum.Tile)
            {
                moveTo(tile);
                return true;
            }
            else if (tile.getEntityType() == EntityTypesEnum.Rockford)
            {
                Rockford rf = tile.Entity as Rockford;
                rf.kill();
                return true;
            }
            else if (tile.getEntityType() == EntityTypesEnum.Firefly)
            {
                moveTo(tile);
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}