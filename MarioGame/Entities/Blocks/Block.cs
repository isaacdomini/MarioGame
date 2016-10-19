﻿using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites;
using System.Collections.Generic;

namespace MarioGame.Entities
{
    public class Block : PowerUpEntity, IContainer
    {
        // Could be useful for casting in certain circumstances
        protected BlockSprite blockSprite;
        public BlockActionState blockActionState;
        public BlockPowerUpState blockPowerUpState;
        protected BlockActionStateMachine actionStateMachine;
        protected BlockPowerUpStateMachine powerUpStateMachine;
        List<IContainable> containedItems = new List<IContainable>();

        public Block(Vector2 position, ContentManager content) : base(position, content)
        {
            actionStateMachine = new BlockActionStateMachine(this);
            powerUpStateMachine = new BlockPowerUpStateMachine(this);
            aState = actionStateMachine.BrickState;
            powerUpState = powerUpStateMachine.VisibleState;
            blockSprite = (BlockSprite)_sprite;
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
            blockSprite.changeActionState(aState);

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
            blockSprite.changePowerUp(powerUpState);
        }
        public void ChangeBlockActionState(BlockActionState state)
        {
            base.ChangeActionState(state);
            blockSprite.changeActionState(state);
        }

        public void ChangeBlockPowerUpState(BlockPowerUpState state)
        {
            base.ChangePowerUpState(state);
            blockSprite.changePowerUp(state);
        }

        public void ChangeToUsed()
        {
            ((BlockActionState)aState).ChangeToUsed();
        }
        public void Bump()
        {
            if (((BlockActionState)aState).bState == BlockActionStateEnum.BrickBlock)
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

        public void addContainedItem(IContainable containedItem)
        {
            containedItems.Add(containedItem);
        }

        public IContainable popContainedItem()
        {
            throw new NotImplementedException();
        }

        public bool hasItems()
        {
            throw new NotImplementedException();
        }
    }
}
