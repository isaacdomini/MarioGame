
using MarioGame.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.States.EnemyStates;
using MarioGame.States.PlayerStates;

namespace MarioGame.Entities.EnemyEntities
{
    public class GoombaEntity : Entity
    {
        public GoombaSprite eSprite;
        private GoombaActionState eState;
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        public GoombaEntity(Vector2 position, Sprite sprite) : base(position, sprite)
	    {
            aState = new WalkingGoombaState(this);
            eSprite = (GoombaSprite)_sprite;
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)(_position.X+3), (int)(_position.Y+5), _width/2, _height / 4);
            boxColor = Color.Red;
        }
        public void ChangeActionState(ActionState state)
        {
            aState = state;
            aState.setDirection(state.direction);
        }
        public override void Halt()
        {
            _position -= _velocity;
            ((GoombaActionState)aState).Halt();
        }
        public void SetVelocityToIdle()
        {
            this.setVelocity(idleVelocity);
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
