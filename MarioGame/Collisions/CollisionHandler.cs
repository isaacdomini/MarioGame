using MarioGame.Entities;
using MarioGame.Entities.BlockEntities;
using MarioGame.Entities.EnemyEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Theming;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Collisions
{
    public class CollisionHandler
    {
        public CollisionHandler() 
        {
        }
        public bool checkForCollision(Entity entity1, Entity entity2)
        {
            bool check = false;
            // Add this line when bounding boxes have been initialized and dealt with for all entities
            if (entity1.boundingBox.Intersects(entity2.boundingBox)) check = true;
            return check;
        }


    }

}
