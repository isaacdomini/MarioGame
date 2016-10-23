﻿using MarioGame.Entities;
namespace MarioGame.States
{
    class JumpingMarioState : MarioActionState
    {
        public JumpingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Jumping;
        }
        //TODO: need to add in behavior for jumping higher if you hold the jump button down.
        public override void Begin(MarioActionState prevState)
        {
            _mario.ChangeActionState(stateMachine.JumpingMarioState);
            _mario.SetVelocityToJumping();
        }
        public override void Fall()
        {
            Crouch();
        }

        public override void Crouch()
        {
            stateMachine.IdleMarioState.Begin(this);
        }
        public override void MoveRight()
        {
            if (_mario.isFacingRight())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
            else
            {
                _mario.turnRight();
            }
        }
        public override void MoveLeft()
        {
            if (_mario.isFacingLeft())
            {
                stateMachine.WalkingMarioState.Begin(this);
            }
            else
            {
                _mario.turnLeft();
            }
        }
    }
}
