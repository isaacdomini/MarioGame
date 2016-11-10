using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    internal class PirahnaDeadState : PirahnaActionState
    {
        private int _elapsedMilliseconds;
        public PirahnaDeadState(Pirahna entity, PirahnaStateMachine stateMachine) : base(entity, stateMachine)

        {
            EnemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Pirahna.SetVelocityToIdle();
            //Pirahna.ChangeActionState(StateMachine.DeadState);
            _elapsedMilliseconds = 0;
        }

        public override void UpdateEntity(int elapsedMilliseconds)
        {
            _elapsedMilliseconds += elapsedMilliseconds;
            if (_elapsedMilliseconds > 1000)
            {
                _elapsedMilliseconds = 0;
                Pirahna.Delete();
            }
        }

        public override void ChangeToDead()
        {
            //Do nothing. Intentionally left blank as base is not nothing
        }
    }
}
