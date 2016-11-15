using MarioGame.Entities;
using MarioGame.States;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame.Sprites
{
    public class GreenPipeSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        protected bool Inverted => ((GreenPipe)Entity).Inverted;
        protected SpriteEffects FlippedVertical => Inverted ? SpriteEffects.FlipVertically : SpriteEffects.None;

        public GreenPipeSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "GreenPipe";
        }
        public override void Draw(SpriteBatch batch)
        {
            var sourceRect = new Rectangle(((int)FrameSet[FrameSetPosition]) * FrameWidth, ((int)RowSet[RowSetPosition]) * FrameHeight, FrameWidth, FrameHeight);
            batch.Draw(texture: Texture, position: Position, sourceRectangle: sourceRect, color: Color.White, effects: FlippedVertical);
        }
    }
}