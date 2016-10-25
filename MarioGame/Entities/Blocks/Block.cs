using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Core;

namespace MarioGame.Entities
{
    public class Block : PowerUpEntity, IContainer
    {
        // Could be useful for casting in certain circumstances
        protected BlockSprite BlockSprite;
        public BlockActionState BlockActionState;
        public BlockPowerUpState BlockPowerUpState;
        protected BlockActionStateMachine ActionStateMachine;
        protected BlockPowerUpStateMachine PowerUpStateMachine;
        List<IContainable> _containedItems = new List<IContainable>();

        protected bool IsVisible;
        private int _tickCount;

        public bool Visibility;

        public Block(Vector2 position, ContentManager content) : base(position, content)
        {
            ActionStateMachine = new BlockActionStateMachine(this);
            PowerUpStateMachine = new BlockPowerUpStateMachine(this);
            AState = ActionStateMachine.BrickState;
            // Temporary
            AState._prevState = ActionStateMachine.BrickState;
            PState = PowerUpStateMachine.VisibleState;
            BlockActionState = (BlockActionState)AState;
            BlockPowerUpState = (BlockPowerUpState)PState;
            BlockSprite = (BlockSprite)Sprite;
            _tickCount = 0;
        }
        public void SetBlockActionState(string state)
        {
            if (state.Equals("UsedBlockState"))
            {
                ActionStateMachine.UsedState.Begin(AState);
            }
            else if (state.Equals("BrickBlockState"))
            {
                ActionStateMachine.BrickState.Begin(AState);
            }
            else if (state.Equals("GroundBlockState"))
            {
                ActionStateMachine.GroundState.Begin(AState);
            }
            else if (state.Equals("QuestionBlockState"))
            {
                ActionStateMachine.QuestionState.Begin(AState);
            }
            else if (state.Equals("StepBlockState"))
            {
                ActionStateMachine.StepState.Begin(AState);
            }

        }
        public void SetBlockPowerUpState(string state)
        {
            if (state.Equals("HiddenState"))
            {
                PowerUpStateMachine.HiddenState.Begin(PState);
                //this.ChangeBlockPowerUpState(pState);
            }
            else if (state.Equals("VisibleState"))
            {
                PowerUpStateMachine.VisibleState.Begin(PState);
            }
        }
        public void ChangeBlockActionState(BlockActionState state)
        {
            base.ChangeActionState(state);
            BlockSprite.ChangeActionState(state);
        }

        public void ChangeBlockPowerUpState(BlockPowerUpState state)
        {
            base.ChangePowerUpState(state);
            BlockSprite.ChangePowerUp(state);
        }

        public void ChangeToUsed()
        {
            ((BlockActionState)AState).ChangeToUsed();
        }
        public override void OnCollide(IEntity otherObject, Sides side)
        {
            if (!(otherObject is Mario)) return;
            if(side == Sides.Bottom)
            {
                Bump();
            }
        }
        public void Bump()
        {
            //if bumpable
                if(_tickCount == 0)
                {
                    _tickCount = 10;
                    _velocity.Y = -1;
                }
                // TODO: Begin bumping sequence
                // TODO: If there is no item, change to used.
                ChangeToUsed();
                // TODO: If there is an item, display item, and bump
            //else break
        }
        // Only called when mario is super
        public void Break()
        {
            if (this.CurrentActionState is QuestionBlockState /*or  bumpable blockstate*/)
            {
                this.Bump();
            }
            else
            {
                // TODO: Begin breaking sequence
            }
        }
        public void Reveal()
        {
            ((BlockPowerUpState)PState).Reveal();
        }

        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
            if (_tickCount > 1)
            {
                _tickCount--;
            }
            else if (_tickCount == 1)
            {
                _tickCount = -10;
                _velocity.Y = 1;
            }
            else if (_tickCount < -1)
            {
                _tickCount++;
            }
            else if (_tickCount == -1)
            {
                _tickCount = 0;
                _velocity.Y = 0;
            }
        }

        public void AddContainedItem(IContainable containedItem)
        {
            _containedItems.Add(containedItem);
        }

        public IContainable PopContainedItem()
        {
            throw new NotImplementedException();
        }

        public bool HasItems()
        {
            throw new NotImplementedException();
        }
    }
}
