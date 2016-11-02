using MarioGame.Core;
using MarioGame.Entities;
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
