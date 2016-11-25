using MarioGame.Entities;
using Microsoft.Xna.Framework;

namespace MarioGame.States
{
    public class EnemyPlayerActionState : EnemyActionState
    {
        public EnemyActionStateEnum EnemyState
        { get; protected set; }

        private EnemyPlayer _enemy;
        protected EnemyPlayer EnemyPlayer => _enemy;
        private EnemyPlayerStateMachine _stateMachine;
        protected EnemyPlayerStateMachine StateMachine => _stateMachine;
        public EnemyPlayerActionState(EnemyPlayer entity, EnemyPlayerStateMachine stateMachine) : base(entity)
        {
            _stateMachine = stateMachine;
            _enemy = entity;
        }

        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
        public override void ChangeToDead()
        {
            StateMachine.DeadState.Begin(this);
        }
        public virtual void MoveLeft()
        {
            if (EnemyPlayer.FacingRight)
            {
                EnemyPlayer.TurnLeft();
            }
            else
            {
                EnemyPlayer.SetXVelocity(Vector2.One * -1.75f);
            }
        }
        public virtual void MoveRight()
        {
            if (EnemyPlayer.FacingLeft)
            {
                EnemyPlayer.TurnRight();
            }
            else
            {
                EnemyPlayer.SetXVelocity(Vector2.One * 1.75f);
            }
        }
        public virtual void Fall()
        {
        }
    }
}
