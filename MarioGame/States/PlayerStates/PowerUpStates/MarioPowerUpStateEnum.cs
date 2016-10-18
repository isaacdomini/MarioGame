using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States
{
    public enum MarioPowerUpStateEnum
    {
        Standard,
        Super,
        Fire,
        SuperStar,
        FireStar,
        StandardStar,
        Invincible, //switch between mario, luigi, and fire
        Dead
    }
}
