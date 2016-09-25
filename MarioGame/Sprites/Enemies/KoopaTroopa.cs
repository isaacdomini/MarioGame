using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class KoopaTroopa : Sprite
    {
        private int _frameCount, _frame;
        private readonly Scene _scene;
        private float _totalElapsed, _velocity, _timePerFrame;


        public KoopaTroopa(Vector2 spritePos, Scene scene)
        {
            Visible = false;
            _position = spritePos;
            _scene = scene;
        }

        public void Load(ContentManager content, string asset, int frameCount, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(asset);
            _totalElapsed = 0;
            _velocity = 1f;
            _frameCount = frameCount;
            _frame = 0;
            _timePerFrame = (float)1 / framesPerSecond;
        }


        public override void Update(float elapsed)
        {
            if (Visible)
            {
                _totalElapsed += elapsed;
                if (_totalElapsed > _timePerFrame)
                {
                    if(_frame == 13)
                    {
                        _frame = 2;
                    }
                    _frame++;
                    _frame = _frame % _frameCount;
                    _totalElapsed -= _timePerFrame;
                }
                _position.X += _velocity;
                if (_position.X > _scene.Stage.Game1.GraphicsDevice.Viewport.Width)
                    _velocity =-1*_velocity;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                var frameWidth = _texture.Width / _frameCount;
                var sourcerect = new Rectangle(frameWidth * _frame, 0, frameWidth, _texture.Height);
                batch.Draw(_texture, _position, sourcerect, Color.White);
            }
        }
    }
}