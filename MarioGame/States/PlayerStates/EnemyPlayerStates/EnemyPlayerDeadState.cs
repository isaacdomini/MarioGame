using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Theming;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    internal class EnemyPlayerDeadState : EnemyPlayerActionState
    {
        private int _elapsedMilliseconds;
        public EnemyPlayerDeadState(EnemyPlayer entity, EnemyPlayerStateMachine stateMachine) : base(entity, stateMachine)

        {
            EnemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            EnemyPlayer.SetVelocityToIdle();
            EnemyPlayer.ChangeActionState(StateMachine.DeadState);
            _elapsedMilliseconds = 0;
            //Entities.Entity.Script.Announce(EventTypes.Stomp);
        }

        public override void UpdateEntity(int elapsedMilliseconds)
        {
            _elapsedMilliseconds += elapsedMilliseconds;
            if (_elapsedMilliseconds > 1000)
            {
                _elapsedMilliseconds = 0;
                EnemyPlayer.Delete();
            }
        }

        public override void ChangeToDead()
        {
            //Do nothing. Intentionally left blank as base is not nothing
        }
    }
}
