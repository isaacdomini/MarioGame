using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class Star : ISprite
    {
        private int _frameCount, _frame;
        private readonly Scene _scene;
        private float _totalElapsed, _velocity, _timePerFrame;
        Vector2 _position;
        protected Texture2D _texture;
        protected string _assetName;
        protected ContentManager _content;
        protected Viewport _viewport;
        public bool Visible { get; set; }


        public Star(Vector2 spritePos, Scene scene)
        {
            Visible = false;
            _position = spritePos;
            _scene = scene;
        }

        public void Load(int framesPerSecond = 1)
        {
            _texture = _content.Load<Texture2D>(_assetName);
            _totalElapsed = 0;
            _velocity = 1f;
            _frameCount = 9;
            _frame = 0;
            _timePerFrame = (float)1 / framesPerSecond;
        }


        public void Update(float elapsed)
        {
        }

        public void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                var frameWidth = _texture.Width / _frameCount;
                var sourcerect = new Rectangle(frameWidth * _frame, _texture.Height *3/4, frameWidth, _texture.Height *1/4);
                batch.Draw(_texture, _position, sourcerect, Color.White);
            }
        }
    }
}