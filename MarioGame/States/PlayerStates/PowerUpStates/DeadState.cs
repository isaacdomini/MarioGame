﻿using MarioGame.Entities;
using MarioGame.Theming;

namespace MarioGame.States
{
    internal class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Dead;
        }

        public override void Begin(MarioPowerUpState prevState)
        {
            Mario.ChangePowerUpState(StateMachine.DeadState);
            Mario.SetVelocityToIdle();
            Entities.Entity.Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.powerdown.GetHashCode()]);
            //MarioGame.Entities.Entity.Script.Reset();
        }
    }
}
