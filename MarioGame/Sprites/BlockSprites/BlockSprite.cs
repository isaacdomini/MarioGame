using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using MarioGame.States;

namespace MarioGame.Sprites
{
    public class BlockSprite : HidableSprite
    {
        public enum Rows
        {
            Visible = 0,
            Hidden = 1
        }

        public BlockSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            RowSets = new Dictionary<int, Collection<int>>
            {
                {Rows.Visible.GetHashCode(), new Collection<int> {Rows.Visible.GetHashCode() } }
            };
            RowSet = RowSets[Rows.Visible.GetHashCode()];

        }
        public override void Load(int framesPerSecond = 5)
        {
            base.Load(framesPerSecond);
            FrameHeight = 16;
        }
        public void ChangeActionState(BlockActionState actionState)
        {
            base.ChangeActionState();
            FrameSet = FrameSets[actionState.BState.GetHashCode()];
        }
    }
}