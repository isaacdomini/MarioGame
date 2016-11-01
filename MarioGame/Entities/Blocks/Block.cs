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
    public abstract class Block : HidableEntity
    {
        protected BlockActionStateMachine ActionStateMachine;
        protected BlockActionStateEnum BEntity;


        public Block(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            ActionStateMachine = new BlockActionStateMachine(this);
            AState = ActionStateMachine.StandardState;
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
        public virtual void ChangeToStandard() { }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
        }
    }
}
