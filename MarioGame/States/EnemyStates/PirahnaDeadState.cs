using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    internal class PirahnaDeadState : PirahnaActionState
    {
        Pirahna pirahna;
        private int _elapsedMilliseconds;
        public PirahnaDeadState(Pirahna entity, PirahnaStateMachine stateMachine) : base(entity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Dead;
            pirahna = entity;
        }
        public override void Begin(IState prevState)
        {
            pirahna.Delete();
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
            Pirahna.ChangeActionState(StateMachine.DeadState);
        }
    }
}
