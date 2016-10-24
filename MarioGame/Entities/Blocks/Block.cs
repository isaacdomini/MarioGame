using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

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
        private static int boundingBoxWidth = 18;
        private static int boundingBoxHeight = 18;

        protected bool isVisible;
        private int tickCount;

        internal bool Visibility;

        public Block(Vector2 position, ContentManager content) : base(position, content)
        {
            actionStateMachine = new BlockActionStateMachine(this);
            powerUpStateMachine = new BlockPowerUpStateMachine(this);
            aState = actionStateMachine.BrickState;
            // Temporary
            aState._prevState = actionStateMachine.BrickState;
            pState = powerUpStateMachine.VisibleState;
            blockActionState = (BlockActionState)aState;
            blockPowerUpState = (BlockPowerUpState)pState;
            blockSprite = (BlockSprite)_sprite;
            tickCount = 0;
        }
        public void SetBlockActionState(String state)
        {
            if (state.Equals("UsedBlockState"))
            {
                actionStateMachine.UsedState.Begin(aState);
            }
            else if (state.Equals("BrickBlockState"))
            {
                actionStateMachine.BrickState.Begin(aState);
            }
            else if (state.Equals("GroundBlockState"))
            {
                actionStateMachine.GroundState.Begin(aState);
            }
            else if (state.Equals("QuestionBlockState"))
            {
                actionStateMachine.QuestionState.Begin(aState);
            }
            else if (state.Equals("StepBlockState"))
            {
                actionStateMachine.StepState.Begin(aState);
            }

        }
        public void SetBlockPowerUpState(String state)
        {
            if (state.Equals("HiddenState"))
            {
                powerUpStateMachine.HiddenState.Begin(pState);
                //this.ChangeBlockPowerUpState(pState);
            }
            else if (state.Equals("VisibleState"))
            {
                powerUpStateMachine.VisibleState.Begin(pState);
            }
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
                if(tickCount == 0)
                {
                    tickCount = 10;
                    _velocity.Y = -1;
                }
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
            ((BlockPowerUpState)pState).Reveal();
        }

        public override void Update(Viewport viewport)
        {
            base.Update(viewport);
            if (tickCount > 1)
            {
                tickCount--;
            }
            else if (tickCount == 1)
            {
                tickCount = -10;
                _velocity.Y = 1;
            }
            else if (tickCount < -1)
            {
                tickCount++;
            }
            else if (tickCount == -1)
            {
                tickCount = 0;
                _velocity.Y = 0;
            }
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
