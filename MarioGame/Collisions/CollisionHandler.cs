using MarioGame.Entities;
using MarioGame.Entities.Blocks;
using MarioGame.Entities.Enemies;
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
    public enum CollisionTypes
    {
        Left,
        Right,
        Bottom,
        Top,
        None
    }
    public class CollisionHandler
    {
        public CollisionHandler() 
        {
        }
        public bool checkForCollision(Entity entity1, Entity entity2)
        {
            return entity1.boundingBox.Intersects(entity2.boundingBox);
        }
        public CollisionTypes checkSideCollision(Entity entity1, Entity entity2)
        {
            double width = 0.5 * (entity1.boundingBox.Width + entity2.boundingBox.Width);
            double height = 0.5 * (entity1.boundingBox.Height + entity2.boundingBox.Height);
            double dx = entity1.boundingBox.Center.X - entity2.boundingBox.Center.X;
            double dy = entity1.boundingBox.Center.Y - entity2.boundingBox.Center.Y;
            CollisionTypes toReturn = CollisionTypes.None;

            if (Math.Abs(dx) <= width && Math.Abs(dy) <= height)
            {
                /* collision! */
                double wy = width * dy;
                double hx = height * dx;
                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        toReturn = CollisionTypes.Bottom;
                    }
                    /* collision at the top */
                    else
                    {
                        toReturn = CollisionTypes.Left;

                    }
                    /* on the left */
                }

                else
                {
                    if (wy > -hx)
                    {
                        toReturn = CollisionTypes.Right;
                    }
                    /* on the right */
                    else
                    {
                        toReturn = CollisionTypes.Left;
                    }
                }
                /* at the top */
            }
            return toReturn;
            
        }


    }

}
