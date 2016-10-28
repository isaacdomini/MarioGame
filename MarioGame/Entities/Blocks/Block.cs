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
        protected BlockActionStateMachine ActionStateMachine;
        Queue<IContainable> _containedItems = new Queue<IContainable>();
        protected int _tickCount;

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
            _tickCount = 0;
            floating = true;
        }
        public void SetBlockActionState(string state)
        {
            if (state.Equals("UsedBlockState"))
            {
                ChangeToUsed();
            }
            else if (state.Equals("GroundBlockState"))
            {
                ChangeToGround();
            }
            else if (state.Equals("QuestionBlockState"))
            {
                ChangeToQuestion();
            }
            else if (state.Equals("StepBlockState"))
            {
                ChangeToStep();
            }

        }
        public override void OnCollide(IEntity otherObject, Sides side)
        {
            if (!(otherObject is Mario)) return;
            if (side == Sides.Bottom)
            {
                Bump();
            }
        }
        public void ChangeActionState(BlockActionState state)
        {
            base.ChangeActionState(state);
            ((BlockSprite)Sprite).ChangeActionState(state);
        }

        public void ChangeToUsed()
        {
            ((BlockActionState)AState).ChangeToUsed();
        }
        private void ChangeToStep()
        {
            ((BlockActionState)AState).ChangeToStep();
        }
        private void ChangeToQuestion()
        {
            ((BlockActionState)AState).ChangeToQuestion();
        }
        private void ChangeToGround()
        {
            ((BlockActionState)AState).ChangeToGround();
        }

        public virtual void Bump()
        {
            //if bumpable
            if (AState is BrickBlockState || AState is QuestionBlockState)
            {
                if (_tickCount == 0)
                {
                    _tickCount = 10;
                    _velocity.Y = -1;
                }
                if (HasItems())
                {
                   IContainable poppedItem = PopContainedItem();
                   poppedItem.LeaveContainer();
                    // TODO: Make poppedItem appear and pop out
                } else if (AState is BrickBlockState)
                {
                    ChangeToUsed();
                }
                _isVisible = true;
            }
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
