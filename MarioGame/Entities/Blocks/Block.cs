using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public abstract class Block : Entity
    {
        // Could be useful for casting in certain circumstances
        public BlockActionState actionState;
        public BlockPowerUpState powerUpState;
        protected BlockActionStateMachine stateMachine;

        protected bool isVisible;

        internal bool Visibility
        {
            get { return isVisible; }
        }

        public Block(Vector2 position, ContentManager content) : base(position, content)
        {
            isVisible = true;
        }

        public void ChangeBrickActionState(BlockActionState state)
        {
            actionState = state;
        }
        public void ChangeBrickPowerUpState(BlockPowerUpState state)
        {

        }

        public virtual void ChangeToUsed() { }
        public virtual void Bump() { }
        public virtual void Break() { }
        public virtual void Reveal() { }
    }
}
