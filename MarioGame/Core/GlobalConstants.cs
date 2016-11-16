using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Core;

namespace MarioGame.Theming
{
    public static class GlobalConstants
    {
        public const int GridHeight = 16;
        public const int GridWidth = 16;
        public const float MillisecondsPerFrame = 16;
        public const int FramesPerSecond = 5;


        public static readonly string[] SFXFiles = Enum.GetNames(typeof(EventTypes)).Select(s => s.ToLowerInvariant()).ToArray();
    }
}
