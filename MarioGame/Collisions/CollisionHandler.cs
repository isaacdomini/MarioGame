using MarioGame.Entities;
using MarioGame.Entities.BlockEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Theming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Collisions
{
    public class CollisionHandler
    {
        MarioEntity _mario;
        List<BlockEntity> _blocks;
        List<Entity> _items;
        List<Entity> _enemies;
        public CollisionHandler(MarioEntity mario, List<BlockEntity> blocks, List<Entity> items, List<Entity> enemies) 
        {
            _mario = mario;
            _blocks = blocks;
            _items = items;
            _enemies = enemies;
        }
        public bool checkForCollision(Entity entity1, Entity entity2)
        {
            bool check = false;
            // Add this line when bounding boxes have been initialized and dealt with for all entities
            //if (entity1.boundingBox.Intersects(entity2.boundingBox)) check = true;
            return check;
        }

        public void handleMarioCollisions()
        {
            foreach (var block in _blocks)
            {
                if (checkForCollision(_mario, block)){
                    _mario.Halt();
                }
            }
        }
    }

}
