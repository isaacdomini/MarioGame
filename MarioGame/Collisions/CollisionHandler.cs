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
        public string checkSideCollision(Entity entity1, Entity entity2)
        {

            double width = 0.5 * (entity1.boundingBox.Width + entity2.boundingBox.Width);
            double height = 0.5 * (entity1.boundingBox.Height + entity2.boundingBox.Height);
            double dx = entity1.boundingBox.Center.X - entity2.boundingBox.Center.X;
            double dy = entity1.boundingBox.Center.Y - entity2.boundingBox.Center.Y;
            string toReturn = "";

            if (Math.Abs(dx) <= width && Math.Abs(dy) <= height)
            {
                /* collision! */
                double wy = width * dy;
                double hx = height * dx;
                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        toReturn = "b";
                    }
                    /* collision at the top */
                    else
                    {
                        toReturn = "l";

                    }
                }
                /* on the left */
                else
                {
                    if (wy > -hx)
                    {
                        toReturn = "r";
                    }
                    /* on the right */
                    else
                    {
                        toReturn = "t";
                    }
                }
                /* at the bottom */
            }
            return toReturn;
            
        }


    }

}
