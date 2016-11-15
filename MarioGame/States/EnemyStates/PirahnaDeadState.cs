using MarioGame.Entities;
using MarioGame.Theming;
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
            Pirahna.Delete();
            Mario.Scoreboard.AddPoint(200);
            Entities.Entity.Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.stomp.GetHashCode()]);
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
