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
    public class Block : Entity, IContainer, IHidable
    {
        // Could be useful for casting in certain circumstances
        protected BlockSprite BlockSprite;
        public BlockActionState BlockActionState;
        protected BlockActionStateMachine ActionStateMachine;
        Queue<IContainable> _containedItems = new Queue<IContainable>();
        private int _tickCount;

        protected bool _isVisible;

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
        }

        public Block(Vector2 position, ContentManager content) : base(position, content)
        {
            ActionStateMachine = new BlockActionStateMachine(this);
            AState = ActionStateMachine.BrickState;
            // Temporary
            AState.PrevState = ActionStateMachine.BrickState;
            BlockActionState = (BlockActionState)AState;
            BlockSprite = (BlockSprite)Sprite;
            _tickCount = 0;
            floating = true;
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
        public void ChangeBlockActionState(BlockActionState state)
        {
            base.ChangeActionState(state);
            BlockSprite.ChangeActionState(state);
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
            _isVisible = true;
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
            _containedItems.Enqueue(containedItem);
        }

        public IContainable PopContainedItem()
        {
            return _containedItems.Dequeue();
        }

        public bool HasItems()
        {
            return _containedItems.Count > 0;
        }

        public void Hide()
        {
            _isVisible = false;
        }

        public void Show()
        {
            _isVisible = true;
        }
    }
}
