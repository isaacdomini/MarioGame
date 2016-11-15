using MarioGame.Entities;
using Microsoft.Xna.Framework;
using System;

namespace MarioGame.States
{
    internal class CrouchingMarioState : MarioActionState
    {
        //TODO: Shouldn't this state only be able to be called when in Giant Mario Power State?
        public CrouchingMarioState(Mario entity, MarioActionStateMachine stateMachine) : base(entity, stateMachine)
        {
            actionState = MarioActionStateEnum.Crouching;
        }
        public override void Begin(MarioActionState prevState)
        {
            Mario.ChangeActionState(StateMachine.CrouchingMarioState);
            base.Begin(prevState);
        }
        public override void Jump()
        {
            StateMachine.IdleMarioState.Begin(this);
        }

        public override void HitTopOfGreenPipe(Action<Mario, Vector2> sceneTransport, Vector2 transportPosition)
        {
            if (sceneTransport != null)
            sceneTransport.Invoke(Mario, transportPosition);
            else if (transportPosition != Vector2.Zero)
            {
                Mario.SetPosition(transportPosition);
                Jump();
            }
        }
    }
}
