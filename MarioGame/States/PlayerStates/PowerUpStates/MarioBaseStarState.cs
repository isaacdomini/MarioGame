using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Core;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    internal class BaseStarState : MarioPowerUpState
    {
        public BaseStarState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Entities.Entity.Script.Announce(EventTypes.BeginStarState);    
        }

        public override void EndState()
        {
            base.EndState();
            Entities.Entity.Script.Announce(EventTypes.EndStarState);
        }
    }
}
