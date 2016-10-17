using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.States.PlayerStates
{
    public enum MarioPowerUpStateEnum
    {
        Standard,
        Super,
        Fire,
        Star,
        Invincible, //switch between mario, luigi, and fire
        Dead
    }
}
