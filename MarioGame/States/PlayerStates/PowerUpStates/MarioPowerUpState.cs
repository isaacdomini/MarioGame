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
            Console.WriteLine("marioPowerUpState.changeToDead() about to be called. mario is DeadState:" + (this is DeadState));
            Console.WriteLine("marioPowerUpState.changeToDead() about to be called. _stateMachine.DeadState is" + (_stateMachine.DeadState is DeadState));
            _mario.ChangePowerUpState(_stateMachine.DeadState);
            Console.WriteLine("marioPowerUpState.changeToDead() was just called. mario is DeadState:" + (this is DeadState));
            Console.WriteLine("marioPowerUpState.changeToDead() was just called. pState's type is " + _mario.CurrentPowerUpState.GetType());
            Console.WriteLine("marioPowerUpState.changeToDead() was just called. marioPowerUpState's type is " + this.GetType());
            Console.WriteLine("marioPowerUpState.changeToDead() was just called. marioPowerUpState's type (v2)is " + _mario.marioPowerUpState.GetType());
            Console.WriteLine("marioPowerUpState.changeToDead() was just called. pState's type is " + _mario.CurrentPowerUpState.GetType());
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
            _mario.setInvincible(10);
        }
        public virtual void onHitByEnemy() { }
    }
}
