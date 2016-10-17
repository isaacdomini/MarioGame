
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.States.EnemyStates;
using Microsoft.Xna.Framework;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Goomba : Enemy
    {
        //public GoombaSprite eSprite;
        private GoombaActionState eState;
        public Goomba(Vector2 position, ContentManager content) : base(position, content)
        {
            aState = new WalkingGoombaState(this);
            eSprite = (GoombaSprite)_sprite;
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)(_position.X + 3), (int)(_position.Y + 5), _width / 2, _height / 4);
            boxColor = Color.Red;
        }
        
        public override void Halt()
        {
            _position -= _velocity;
            ((GoombaActionState)aState).Halt();
        }

        public void ChangeToDeadState()
        {
            eState.ChangeToDead();
        }
        public override void Update(Viewport viewport)
        {
            _position += _velocity;
            boundingBox.X = (int)_position.X;
            boundingBox.Y = (int)_position.Y;
        }
    }

}
