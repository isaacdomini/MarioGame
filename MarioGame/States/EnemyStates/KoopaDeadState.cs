using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Theming;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    internal class KoopaDeadState : KoopaActionState
    {
        public KoopaDeadState(KoopaTroopa entity, KoopaStateMachine stateMachine) : base(entity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Koopa.SetVelocityToIdle();
            Koopa.ChangeActionState(StateMachine.DeadState);
            Entities.Entity.Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.stomp.GetHashCode()]);
            Mario.Scoreboard.AddPoint(100);        
}
        public override void JumpedOn(Sides side)
        {
            if (side == Sides.Right)
            {
                Koopa.TurnLeft();
            }
            else
            {
                Koopa.TurnRight();
            }
            StateMachine.BouncingState.Begin(this);
        }

        public override void HitByMarioSide()
        {
            Koopa.SetShellVelocityToMoving();
        }
    }
}
