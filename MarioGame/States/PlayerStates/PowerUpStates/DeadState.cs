using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class DeadState : PowerUpState
    {
        public DeadState(IEntity entity) : base(entity)
        {
        }
    }
}
