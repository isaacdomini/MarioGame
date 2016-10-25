using MarioGame.Entities;

namespace MarioGame.States
{
    internal class WalkingGoombaState : GoombaActionState
    {
        //private Goomba enemyEntity;

        public WalkingGoombaState(Goomba enemyEntity, GoombaStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            EnemyState = EnemyActionStateEnum.Walking;
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
            Goomba.SetVelocityToWalk();
            Goomba.ChangeActionState(StateMachine.WalkingGoomba);
        }
        
    }
}
