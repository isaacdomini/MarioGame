
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.EnemyEntities
{
    public class GoombaEntity : Entity
    {

        // Velocity variables
        public readonly static int velocityConstant = 1;
        private GoombaSprite gSprite;
        public Viewport viewport;
        IEntity goomba;
        ContentManager content;

        public GoombaEntity(Vector2 position, ISprite sprite) : base(position, sprite)
        {
            gSprite = new GoombaSprite(goomba, content, viewport);
        }
        public override void Update(){}
    }

}
