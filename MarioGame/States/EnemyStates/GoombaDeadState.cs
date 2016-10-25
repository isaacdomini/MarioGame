using MarioGame.Entities;

namespace MarioGame.States
{
    internal class GoombaDeadState : GoombaActionState
    {
        public GoombaDeadState(Goomba entity, GoombaStateMachine stateMachine) : base(entity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Dead;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Goomba.SetVelocityToIdle();
            Goomba.ChangeActionState(StateMachine.DeadGoomba);
        }
    }
}
