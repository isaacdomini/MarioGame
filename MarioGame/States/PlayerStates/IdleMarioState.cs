using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    class IdleMarioState : MarioState
    {
        public IdleMarioState(IEntity entity) : base(entity)
        {
            
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
        public override void Jump()
        {
            MarioState newState = new JumpingMarioState(_entity);
            _entity.ChangeState(newState);
            newState.Begin(this);

        }
    }
}
