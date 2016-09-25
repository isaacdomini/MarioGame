using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class AnimatedMovingSprite : Sprite
    {
        private int _frameCount, _frame;
        private readonly Scene _scene;
        private float _totalElapsed, _velocity, _timePerFrame;


        public AnimatedMovingSprite(Vector2 spritePos, Scene scene)
        {
            Visible = false;
            _position = spritePos;
            _scene = scene;
        }

        public void Load(ContentManager content, string asset, int frameCount = 1, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(asset);
            _totalElapsed = 0;
            _velocity = 1f;
            _frameCount = frameCount;
            _frame = 0;
            _timePerFrame = (float) 1/framesPerSecond;
        }

        public bool Visible { get; set; }

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
                _position.X += _velocity;
                if (_position.X > _scene.Stage.Game1.GraphicsDevice.Viewport.Width)
                    _position.X = 0;
            }
        }

        public void Draw(SpriteBatch batch)
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