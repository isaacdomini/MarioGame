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
        public virtual void ChangeToSuper() { }
        public virtual void ChangeToStandard() { }
        public virtual void ChangeToFire() { }
        public virtual void ChangeToDead() { }
        public virtual void EnemyHit() { }
    }
}
