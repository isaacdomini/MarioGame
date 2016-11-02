using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Sprites
{
    public interface ISprite
    {
        void Load(int framesPerSecond);
        void Update(float elapsed);
        void Draw(SpriteBatch batch);
    }
}