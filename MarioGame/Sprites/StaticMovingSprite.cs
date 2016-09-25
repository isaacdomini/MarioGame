﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class StaticMovingSprite : Sprite
    {
        private float _totalElapsed, _velocity;

        public StaticMovingSprite(Vector2 spritePos)
        {
            Visible = false;
            _position = spritePos;
        }

        public void Load(ContentManager content, string asset, int frameCount = 1, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(asset);
            _totalElapsed = 0;
            _velocity = .5f;
        }

        public new bool Visible { get; set; }

        public override void Update(float elapsed)
        {
            if (Visible)
            {
                _totalElapsed += elapsed;
                if (_totalElapsed > .5f)
                {
                    _velocity *= -1;
                    _totalElapsed -= .5f;
                }
                _position.Y += _velocity;
            }
        }

    }
}