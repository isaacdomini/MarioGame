using MarioGame.Entities;

namespace MarioGame.States
{
    public class MarioPowerUpState : State
    {
        public MarioPowerUpStateEnum powerUpState
        {
            get; protected set;
        }
        protected Mario _mario;
        protected PowerUpStateMachine _stateMachine;
        public MarioPowerUpState(Mario mario, PowerUpStateMachine stateMachine) : base(mario)
        {
            _mario = mario;
            _stateMachine = stateMachine;
        }
        public void Begin(MarioPowerUpState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void ChangeToSuper() { }
        public virtual void ChangeToStandard() { }
        public virtual void ChangeToFire() { }
        public virtual void ChangeToDead() { }
        public virtual void EnemyHit() { }
    }
}
