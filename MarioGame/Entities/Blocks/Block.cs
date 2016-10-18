using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public abstract class Block : PowerUpEntity
    {
        // Could be useful for casting in certain circumstances
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
            base.ChangeActionState(state);
        }
        public void ChangeBrickPowerUpState(BlockPowerUpState state)
        {
            base.ChangePowerUpState(state);
        }

        public void ChangeToUsed()
        {
            ((BlockActionState)aState).ChangeToUsed();
        }
        public void Bump() { }
        public void Break() { }
        public void Reveal() { }
    }
}
