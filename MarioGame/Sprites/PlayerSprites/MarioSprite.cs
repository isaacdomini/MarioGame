using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Entities.PlayerEntities;

namespace MarioGame.Sprites.PlayerSprites
{
    public class MarioSprite : ISprite
    {
        private int _frameCount, _frame, _frameWidth, _frameHeight;
        private float _totalElapsed, _timePerFrame;
        private Point _sheetPosition;
        private Texture2D _texture;
        public bool Visible { get; set; }
        public SpriteEffects Flipped { get; set; }
        private MarioEntity _entity;

        public MarioSprite(MarioEntity entity) : this()
        {
            _entity = entity;
        }

        public MarioSprite()
        {
            Visible = true;
        }

        public void Load(ContentManager content, string asset, int frameCount = 1, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(asset);
            _totalElapsed = 0;
            _frameCount = frameCount;
            _frame = 0;
            _timePerFrame = (float)1 / framesPerSecond;
            Flipped = SpriteEffects.None;
            _sheetPosition = Point.Zero;
            _frameWidth = 1;
            _frameHeight = 1;
        }

        public void ChangeSheet(int frameCount, int frameWidth, int frameHeight, Point sheetPosition)
        {
            _frameCount = frameCount;
            _frameWidth = frameWidth;
            _frameHeight = frameHeight;
            _sheetPosition = sheetPosition;
        }

        public void Update(float elapsed)
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

        public void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                var sourceRect = new Rectangle(_sheetPosition.X, _sheetPosition.Y, _sheetPosition.X + _frameWidth,
                    _sheetPosition.Y + _frameHeight);
                batch.Draw(_texture, _entity.Position, sourceRect, Color.White, Single.Epsilon, Vector2.Zero, Vector2.Zero,
                    Flipped, Single.Epsilon);
            }
        }
    }
}
