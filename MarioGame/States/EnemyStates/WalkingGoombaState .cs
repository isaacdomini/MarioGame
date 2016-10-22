using MarioGame.Entities;

namespace MarioGame.States
{
    class WalkingGoombaState : GoombaActionState
    {
        //private Goomba enemyEntity;

        public WalkingGoombaState(Goomba enemyEntity, GoombaStateMachine stateMachine) : base(enemyEntity, stateMachine)
        {
            enemyState = EnemyActionStateEnum.Walking;
        }
        public override void Begin(GoombaActionState prevState)
        {
            goomba.SetVelocityToWalk();
            goomba.ChangeActionState(_stateMachine.WalkingGoomba);
        }
        
    }
}
