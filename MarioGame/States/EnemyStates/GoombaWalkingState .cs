using MarioGame.Entities;

namespace MarioGame.States
{
    internal class GoombaWalkingState : GoombaActionState
    {
        //private Goomba enemyEntity;

        public GoombaWalkingState(Goomba enemyEntity, GoombaStateMachine stateMachine) : base(enemyEntity, stateMachine)
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
