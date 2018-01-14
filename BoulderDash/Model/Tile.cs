using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoulderDash
{
    public class Tile
    {
        public Entity Entity { get; set; }

        public Tile Up { get; set; }
        public Tile Down { get; set; }
        public Tile Left { get; set; }
        public Tile Right { get; set; }

        public Tile(Entity entity)
        {
            this.Entity = entity;
        }

        public Tile()
        {
        }

        public EntityTypesEnum getEntityType()
        {
            EntityTypesEnum returnType;
            if (Entity == null)
                returnType = EntityTypesEnum.Tile;
            else if (Entity.GetType() == typeof(SteelWall))
                returnType = EntityTypesEnum.SteelWall;
            else if (Entity.GetType() == typeof(Boulder))
                returnType = EntityTypesEnum.Boulder;
            else if (Entity.GetType() == typeof(Diamond))
                returnType = EntityTypesEnum.Diamond;
            else if (Entity.GetType() == typeof(Exit))
                returnType = EntityTypesEnum.Exit;
            else if (Entity.GetType() == typeof(FireFly))
                returnType = EntityTypesEnum.Firefly;
            else if (Entity.GetType() == typeof(Mud))
                returnType = EntityTypesEnum.Mud;
            else if (Entity.GetType() == typeof(Rockford))
                returnType = EntityTypesEnum.Rockford;
            else if (Entity.GetType() == typeof(Wall))
                returnType = EntityTypesEnum.Wall;
            else
                throw new Exception("Unknown entity type");
            return returnType;
        }

        public Entity putOnTile(Entity newEntity)
        {
            Entity oldEntity = Entity;

            oldEntity.tile = null;
            newEntity.tile = this;

            Entity = newEntity;
            return oldEntity;
        }
    }
}