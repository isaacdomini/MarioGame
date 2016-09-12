using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace CSE3902_Sprint0.Sprites
{
    public class StaticStillSprite : ISprite
    {
        private readonly Vector2 _position;
        private Texture2D _texture;

        public StaticStillSprite(Vector2 spritePos)
        {
            Visible = false;
            _position = spritePos;
        }

        public void Load(ContentManager content, string asset, int frameCount = 1, int framesPerSecond = 1)
        {
            _texture = content.Load<Texture2D>(asset);
        }

        public bool Visible { get; set; }

        public void Update(float elapsed)
        {
        }

        public void Draw(SpriteBatch batch)
        {
            if (Visible)
                batch.Draw(_texture, _position);
        }
    }
}