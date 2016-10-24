using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;

namespace MarioGame.States.EnemyStates
{
    public class EnemyActionState : ActionState
    {
        public EnemyActionState(IEntity entity) : base(entity)
        {
        }
        public virtual void Begin(KoopaActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Halt()
        {
            ChangeToDead();
        }
        public virtual void JumpedOn()
        {
            ChangeToDead();
        }

        public virtual void ChangeToDead()
        {
            _stateMachine.DeadState.Begin(this);
        } 
    }
}
