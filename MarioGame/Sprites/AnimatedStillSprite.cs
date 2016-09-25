﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class AnimatedStillSprite : Sprite
    {
        private int _frameCount, _frame;
        private float _totalElapsed, _timePerFrame;

        public AnimatedStillSprite(Vector2 spritePos)
        {
            Visible = false;
            _position = spritePos;
        }

        public void Load(ContentManager content, string asset, int frameCount = 1, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(asset);
            _totalElapsed = 0;
            _frameCount = frameCount;
            _frame = 0;
            _timePerFrame = (float) 1/framesPerSecond;
        }

        public new bool Visible { get; set; }

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
                var frameWidth = _texture.Width/_frameCount;
                var sourcerect = new Rectangle(frameWidth*_frame, 0, frameWidth, _texture.Height);
                batch.Draw(_texture, _position, sourcerect, Color.White);
            }
        }
    }
}