using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public abstract class Block : PowerUpEntity
    {
        // Could be useful for casting in certain circumstances
        protected BlockActionStateMachine actionStateMachine;
        protected BlockPowerUpStateMachine powerUpStateMachine;

        public Block(Vector2 position, ContentManager content) : base(position, content)
        {
            actionStateMachine = new BlockActionStateMachine(this);
            powerUpStateMachine = new BlockPowerUpStateMachine(this);
            aState = actionStateMachine.BrickState;
            powerUpState = powerUpStateMachine.VisibleState;
        }
        public void SetBlockActionState(String state)
        {
            if (state.Equals("UsedBlockState"))
            {
                aState = actionStateMachine.UsedState;
            }
            else if (state.Equals("BrickBlockState"))
            {
                aState = actionStateMachine.BrickState;
            }
            else if (state.Equals("GroundBlockState"))
            {
                aState = actionStateMachine.GroundState;
            }
            else if (state.Equals("QuestionBlockState"))
            {
                aState = actionStateMachine.QuestionState;
            }
            else if (state.Equals("StepBlockState"))
            {
                aState = actionStateMachine.StepState;
            }
        }
        public void SetBlockPowerUpState(String state)
        {
            if (state.Equals("HiddenState"))
            {
                powerUpState = powerUpStateMachine.HiddenState;
            }
            else if (state.Equals("VisibleState"))
            {
                powerUpState = powerUpStateMachine.VisibleState;
            }
        }
        public void ChangeBlockActionState(BlockActionState state)
        {
            base.ChangeActionState(state);
            // TODO: Call sprite to change action state
        }

        public void ChangeBlockPowerUpState(BlockPowerUpState state)
        {
            base.ChangePowerUpState(state);
            // TODO: Call sprite to change power up state
        }

        public void ChangeToUsed()
        {
            ((BlockActionState)aState).ChangeToUsed();
        }
        public void Bump()
        {
            if (((BlockActionState)aState).bState == BlockStateEnum.BrickBlock)
            {
                // TODO: Begin bumping sequence
                // TODO: If there is no item, change to used.
                // TODO: If there is an item, display item, and bump
            }
        }
        // Only called when mario is super
        public void Break()
        {
            // TODO: Begin breaking sequence
        }
        public void Reveal()
        {
            ((BlockPowerUpState)powerUpState).Reveal();
        }
    }
}
