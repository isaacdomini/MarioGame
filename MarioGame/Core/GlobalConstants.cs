using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Theming
{
    public static class GlobalConstants
    {
        public const int GridHeight = 16;
        public const int GridWidth = 16;
        public const float MillisecondsPerFrame = 16;
        public const int FramesPerSecond = 5;
        public enum EventTypes
        {
            OneUp,
            breakblock,
            bump,
            coin,
            fireball,
            flagpole,
            gameover,
            jump,
            pipedown,
            powerdown,
            powerup,
            powerupappear,
            stomp,
            timewarning
        }
    public static readonly string[] SFXFiles = {"1up","breakblock", "bump", "coin", "fireball", "flagpole","gameover","jumpsmall", "pipedown","powerdown","powerup","powerupappear", "stomp", "timewarning"};
    }
}
