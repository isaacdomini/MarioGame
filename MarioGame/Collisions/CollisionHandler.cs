using MarioGame.Core;
using MarioGame.Entities;
using System;

namespace MarioGame.Collisions
{
    public class CollisionHandler
    {
        public CollisionHandler() 
        {
        }
        public bool checkForCollision(Entity entity1, Entity entity2)
        {
            return entity1.boundingBox.Intersects(entity2.boundingBox);
        }

        public Sides checkSideCollision(Entity entity1, Entity entity2)
        {
            double width = 0.5 * (entity1.boundingBox.Width + entity2.boundingBox.Width);
            double height = 0.5 * (entity1.boundingBox.Height + entity2.boundingBox.Height);
            double dx = entity1.boundingBox.Center.X - entity2.boundingBox.Center.X;
            double dy = entity1.boundingBox.Center.Y - entity2.boundingBox.Center.Y;
            Sides toReturn = Sides.None;

            if (Math.Abs(dx) <= width && Math.Abs(dy) <= height)
            {
                /* collision! */
                double wy = width * dy;
                double hx = height * dx;
                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        toReturn = Sides.Bottom;
                    }
                    /* collision at the top */
                    else
                    {
                        toReturn = Sides.Left;

                    }
                }
                /* on the left */
                else
                {
                    if (wy > -hx)
                    {
                        toReturn = Sides.Right;
                    }
                    /* on the right */
                    else
                    {
                        toReturn = Sides.Top;
                    }
                }
                /* at the bottom */
            }

            return toReturn;
            
        }


    }


}
