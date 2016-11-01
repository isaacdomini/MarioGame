using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    internal class GoombaDeadState : GoombaActionState
    {
        private int _elapsedMilliseconds;
        public GoombaDeadState(Goomba entity, GoombaStateMachine stateMachine) : base(entity, stateMachine)

        {
            EnemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Goomba.SetVelocityToIdle();
            Goomba.ChangeActionState(StateMachine.DeadState);
            _elapsedMilliseconds = 0;
        }

        public override void UpdateEntity(int elapsedMilliseconds)
        {
            _elapsedMilliseconds += elapsedMilliseconds;
            if (elapsedMilliseconds > 1000)
            {
                _elapsedMilliseconds = 0;
                Goomba.Delete();
            }
        }

        public override void ChangeToDead()
        {
            //Do nothing. Intentionally left blank as base is not nothing
        }
    }
}
