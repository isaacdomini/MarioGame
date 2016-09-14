using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public interface ISprite
    {
        bool Visible { get; set; }
        void Load(ContentManager content, string asset, int frameCount = 1, int framesPerSecond = 1);
        void Update(float elapsed);
        void Draw(SpriteBatch batch);
    }
}