using MarioGame.Core;
using MarioGame.Entities;
using Microsoft.Xna.Framework;
using System;

namespace MarioGame.Collisions
{
    public static class CollisionHandler
    {

        public static Sides getIntersectingSide(Rectangle box1, Rectangle box2)
        {
            double width = 0.5 * (box1.Width + box2.Width);
            double height = 0.5 * (box1.Height + box2.Height);
            double dx = box1.Center.X - box2.Center.X;
            double dy = box1.Center.Y - box2.Center.Y;
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
