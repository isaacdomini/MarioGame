using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;

namespace MarioGame.Sprites.PlayerSprites
{
    public class MarioSprite : AnimatedSprite
    {
        

        public MarioSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
            _numberOfFrames = 15;
        }

        public override void Update(float elapsed)
        {
            if (Visible)
            {
                _totalElapsed += elapsed;
                if (_totalElapsed > _timePerFrame)
                {
                    _frame++;
                    _frame = _frame%_frameCount;
                    _totalElapsed -= _timePerFrame;
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                var sourceRect = new Rectangle(_sheetPosition.X, _sheetPosition.Y, _sheetPosition.X + _frameWidth,
                    _sheetPosition.Y + _frameHeight);
                batch.Draw(_texture, _entity.getPosition(), sourceRect, Color.White, Single.Epsilon, Vector2.Zero, Vector2.Zero,
                    Flipped, Single.Epsilon);
            }
        }
    }
}
