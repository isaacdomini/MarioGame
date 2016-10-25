using MarioGame.Entities;
using System;

namespace MarioGame.States
{
    public class MarioPowerUpState : PowerUpState
    {
        public MarioPowerUpStateEnum powerUpState
        {
            get; protected set;
        }
        protected Mario _mario { get { return (Mario)_entity; } }
        protected MarioPowerUpStateMachine _stateMachine;
        public MarioPowerUpState(Mario mario, MarioPowerUpStateMachine stateMachine) : base(mario)
        {
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
            //_mario.marioPowerUpState.powerUpState = 
            _stateMachine.DeadState.Begin(this);
        }
        public virtual void ChangeToSuper()
        {
            _mario.ChangePowerUpState(_stateMachine.SuperState);
        }
        public virtual void ChangeToFire()
        {
            _mario.ChangePowerUpState(_stateMachine.FireState);
        }
        public virtual void ChangeToStar() {
            _mario.SetInvincible(10);
        }
        public virtual void onHitByEnemy() { }
        public virtual void onInvincibilityEnded() { }
    }
}
