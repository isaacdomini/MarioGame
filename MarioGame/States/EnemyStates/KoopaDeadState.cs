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
            KoopaTroopa.ShellMovingVelocity = side == Sides.Right ? new Vector2(-2, 0) : new Vector2(2, 0); //TODO put this line in BouncingState.Begin
            StateMachine.BouncingState.Begin(this);
        }

        public override void ChangeToDead()
        {
            //do nothing
        }

        public override void HitByMarioSide()
        {
            
        }
    }
}
