using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Core
{
    public static class Util
    {
        public static Directions flip(Directions d)
        {
            switch (d)
            {
                case Directions.Left:
                    return Directions.Right;
                case Directions.Right:
                    return Directions.Left;
                case Directions.Up:
                    return Directions.Down;
                case Directions.Down:
                    return Directions.Up;
            }
            return Directions.None;
        }
        public static Sides flip(Sides d)
        {
            switch (d)
            {
                case Sides.Left:
                    return Sides.Right;
                case Sides.Right:
                    return Sides.Left;
                case Sides.Top:
                    return Sides.Bottom;
                case Sides.Bottom:
                    return Sides.Top;
            }
            return Sides.None;
        }
    }
}
