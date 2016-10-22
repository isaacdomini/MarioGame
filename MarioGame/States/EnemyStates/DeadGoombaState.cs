using MarioGame.Entities;

namespace MarioGame.States
{
    class DeadGoombaState : GoombaActionState
    {
        public DeadGoombaState(Goomba entity, GoombaStateMachine stateMachine) : base(entity, stateMachine)
        {
            enemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(GoombaActionState prevState)
        {
            goomba.SetVelocityToIdle();
            goomba.ChangeActionState(_stateMachine.DeadGoomba);
        }
    }
}
