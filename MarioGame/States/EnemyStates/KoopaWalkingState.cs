using MarioGame.Core;
using MarioGame.Entities;


namespace MarioGame.States
{
    internal class KoopaWalkingState : KoopaActionState
    {
        //private KoopaTroopaEntity enemyEntity;

        public KoopaWalkingState(KoopaTroopa enemyEntity, KoopaStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Walking;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Koopa.SetVelocityToWalk();
            Koopa.ChangeActionState(StateMachine.WalkingState);
        }
        public override void ChangeToDead()
        {
            StateMachine.DeadState.Begin(this);
        }

        public override void JumpedOn(Sides side)
        {
            //base.JumpedOn(side);
            if(side == Sides.Top)
                ChangeToDead();
        }
    }
}
