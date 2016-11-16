using MarioGame.Entities;
using MarioGame.Theming;
using System;

namespace MarioGame.States
{
    public class MarioPowerUpState : PowerUpState
    {
        public MarioPowerUpStateEnum PowerUpState
        {
            get; protected set;
        }
        protected Mario Mario => (Mario)Entity;
        protected MarioPowerUpStateMachine StateMachine { get; }

        public MarioPowerUpState(Mario mario, MarioPowerUpStateMachine stateMachine) : base(mario)
        {
            StateMachine = stateMachine;
        }
        public virtual void ChangeToStandard()
        {
            StateMachine.StandardState.Begin(this);
        }
        public virtual void ChangeToDead()
        {
            StateMachine.DeadState.Begin(this);
        }
        public virtual void ChangeToSuper()
        {
            StateMachine.SuperState.Begin(this);
        }
        public virtual void ChangeToFire()
        {
            StateMachine.FireState.Begin(this);
        }
        public virtual void ChangeToStar() {
            Mario.SetInvincible(10);
        }
        public virtual void OnHitByEnemy() { }
        public virtual void OnInvincibilityEnded() { }

        public virtual void DashOrThrowFireball()
        {
        }
    }
}
