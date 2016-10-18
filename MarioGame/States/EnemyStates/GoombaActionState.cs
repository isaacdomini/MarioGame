using MarioGame.Entities;
using MarioGame.States.PlayerStates;

namespace MarioGame.States
{
    public class GoombaActionState : ActionState
    {
        public EnemyActionStateEnum enemyState
        { get; protected set; }
        protected Goomba goomba;
        protected GoombaStateMachine _stateMachine;
        public GoombaActionState(Goomba entity, GoombaStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            goomba = entity;
        }

        public virtual void Begin(GoombaActionState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void Halt()
        {
            ChangeToDead();
        }

        public virtual void ChangeToDead()
        {
            _stateMachine.DeadGoomba.Begin(this);
        }
        public virtual void JumpedOn()
        {
            ChangeToDead();
        }
    }
}
