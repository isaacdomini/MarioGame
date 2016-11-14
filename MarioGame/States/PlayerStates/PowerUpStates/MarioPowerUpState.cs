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
        public virtual void Begin(MarioPowerUpState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void ChangeToStandard()
        {
            Mario.ChangePowerUpState(StateMachine.StandardState);
        }
        public virtual void ChangeToDead()
        {
            //_mario.marioPowerUpState.powerUpState = 
            StateMachine.DeadState.Begin(this);
        }
        public virtual void ChangeToSuper()
        {
            Mario.ChangePowerUpState(StateMachine.SuperState);
        }
        public virtual void ChangeToFire()
        {
            Mario.ChangePowerUpState(StateMachine.FireState);
        }
        public virtual void ChangeToStar() {
            Mario.SetInvincible(10);
            if (Mario.CurrentPowerUpState is StandardState)
            {
                Mario.ChangePowerUpState(StateMachine.StandardStarState);
                StateMachine.StandardStarState.Begin(this);
            }
            else
            {
                Mario.ChangePowerUpState(StateMachine.SuperStarState);
                StateMachine.SuperStarState.Begin(this);
            }
        }
        public virtual void OnHitByEnemy() { }
        public virtual void OnInvincibilityEnded() { }
    }
}
