using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class StaticMovingSprite : ISprite
    {
        private float _totalElapsed, _velocity;
        private Vector2 _position;
        private Texture2D _texture;

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

        public bool Visible { get; set; }

        public void Update(float elapsed)
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

        public void Draw(SpriteBatch batch)
        {
            if (Visible)
                batch.Draw(_texture, _position);
        }
    }
}