using MarioGame.Entities;

namespace MarioGame.States
{
    public class KoopaActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }
        public KoopaTroopa Koopa;
        protected KoopaStateMachine StateMachine;
        public KoopaActionState(KoopaTroopa entity, KoopaStateMachine stateMachine) : base(entity)
        {
            StateMachine = stateMachine;
            Koopa = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }

        public override void ChangeToDead()
        {
            StateMachine.DeadState.Begin(this);
        }
        public void ChangeSpriteDirection()
        {
            if (Koopa.Direction == Core.Directions.Right)
            {
                Koopa.turnLeft();
            }
            else
            {
                Koopa.turnRight();
            }
        }
    }
}
