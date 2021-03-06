﻿using System;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.Sprites;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Core;
using MarioGame.States.BlockStates;
using MarioGame.States.BlockStates.ActionStates;
using MarioGame.Theming;

namespace MarioGame.Entities
{
    public abstract class Block : HidableEntity
    {
        public BlockActionStateMachine ActionStateMachine { get; set; }

        protected BlockActionStateEnum BEntity { get; set; }
        protected BlockActionState BState => (BlockActionState) AState;

        internal Block(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            ActionStateMachine = new BlockActionStateMachine(this);
            AState = ActionStateMachine.StandardState;
            floating = true;
        }

        internal override void Init(JEntity e, Game1 game)
        {
            base.Init(e, game);
            if (e.actionState != null)
            {
                SetBlockActionState(e.actionState);
            }
            if (e.visibility != null && e.visibility == "Hidden")
            {
                Hide();
            }
            else
            {
                Show();
            }
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
    }
}
