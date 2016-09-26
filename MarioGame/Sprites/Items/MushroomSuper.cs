using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public class MushroomSuper : Sprite
    {
        private int _frameCount, _frame;
        private readonly Scene _scene;
        private float _totalElapsed, _velocity, _timePerFrame;


        public MushroomSuper(Vector2 spritePos, Scene scene)
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
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                var frameWidth = _texture.Width / _frameCount;
                var sourcerect = new Rectangle(frameWidth * _frame, _texture.Height * 1 / 4, frameWidth, _texture.Height * 1 / 4);
                batch.Draw(_texture, _position, sourcerect, Color.White);
            }
        }
    }
}