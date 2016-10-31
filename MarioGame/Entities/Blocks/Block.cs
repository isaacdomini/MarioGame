using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Core;
using MarioGame.States.BlockStates;
using MarioGame.States.BlockStates.ActionStates;

namespace MarioGame.Entities
{
    public abstract class Block : Entity, IHidable
    {
        protected BlockActionStateMachine ActionStateMachine;
        protected BlockActionStateEnum BEntity;
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
            AState = ActionStateMachine.StandardState;
            IsCollidable = true;
            floating = true;
        }
        public void SetBlockActionState(string state)
        {
            if (state.Equals("UsedBlockState"))
            {
                ChangeToUsed();
            }

        }
        public void ChangeActionState(BlockActionState state)
        {
            base.ChangeActionState(state);
            ((BlockSprite)Sprite).ChangeActionState(state);
        }

        public virtual void ChangeToUsed() { }
        public virtual void Bump() { }
        // Only called when mario is super
        public virtual void Break() { }
        public virtual void ChangeToStandard() { }

        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
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
