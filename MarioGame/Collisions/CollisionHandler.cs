using MarioGame.Core;
using MarioGame.Entities;
using Microsoft.Xna.Framework;
using System;

namespace MarioGame.Collisions
{
    public static class CollisionHandler
    {

        public static Sides GetIntersectingSide(Rectangle box1, Rectangle box2)
        {
            var width = 0.5 * (box1.Width + box2.Width);
            var height = 0.5 * (box1.Height + box2.Height);
            var dx = box1.Center.X - box2.Center.X;
            var dy = box1.Center.Y - box2.Center.Y;
            var toReturn = Sides.None;

            if (!(Math.Abs(dx) <= width) || !(Math.Abs(dy) <= height)) return toReturn;
            /* collision! */
            var wy = width * dy;
            var hx = height * dx;
            if (wy > hx)
            {
                toReturn = wy > -hx ? Sides.Top : Sides.Right;
            }
            /* on the left */
            else
            {
                toReturn = wy > -hx ? Sides.Left : Sides.Bottom;
            }
            /* at the bottom */
            return toReturn;
        }
    }
}
