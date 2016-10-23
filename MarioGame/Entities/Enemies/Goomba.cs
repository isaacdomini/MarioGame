
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.States;
using Microsoft.Xna.Framework;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Goomba : Enemy
    {
        //public GoombaSprite eSprite;
        GoombaActionState eState;
        GoombaStateMachine stateMachine;
        private static int boundingBoxWidth = 10;
        private static int boundingBoxHeight = 10;

        public Goomba(Vector2 position, ContentManager content) : base(position, content)
        {
            stateMachine = new GoombaStateMachine(this);
            aState = stateMachine.WalkingGoomba;
            eState = (GoombaActionState)aState;
            eSprite = (GoombaSprite)_sprite;
            boundingBox = new Rectangle((int)(Position.X + 3), (int)(Position.Y + 5), boundingBoxWidth, boundingBoxHeight);
            boxColor = Color.Red;
        }
        public void ChangeActionState(GoombaActionState newState)
        {
            eState = newState;
            ((GoombaSprite)eSprite).changeActionState(newState);
        }

        public override void Halt()
        {
            Position -= Velocity;
            eState.Halt();
        }

        public void ChangeToDeadState()
        {
            eState.ChangeToDead();
        }
        public override void JumpedOn()
        {
            eState.JumpedOn();
            _isDead = true;
            
        }
        public override void Update(Viewport viewport)
        {
            Position += Velocity;
            boundingBox.X = (int)Position.X + 3;
            boundingBox.Y = (int)Position.Y + 5;
        }
    }
}
