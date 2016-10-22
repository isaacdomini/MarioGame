using MarioGame.Entities;

namespace MarioGame.States
{
    public class MarioPowerUpState : PowerUpState
    {
        public MarioPowerUpStateEnum powerUpState
        {
            get; protected set;
        }
        protected Mario _mario;
        protected MarioPowerUpStateMachine _stateMachine;
        public MarioPowerUpState(Mario mario, MarioPowerUpStateMachine stateMachine) : base(mario)
        {
            _mario = mario;
            _stateMachine = stateMachine;
        }
        public virtual void Begin(MarioPowerUpState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void ChangeToStandard()
        {
            _mario.ChangePowerUpState(_stateMachine.StandardState);
        }
        public virtual void ChangeToDead()
        {
            _mario.ChangePowerUpState(_stateMachine.DeadState);
        }
        public virtual void ChangeToSuper()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperState);
        }

        public virtual void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public virtual void ChangeToStar() { }
        public virtual void EnemyHit() { }
    }
}
