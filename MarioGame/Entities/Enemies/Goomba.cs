
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
            boundingBox = new Rectangle((int)(_position.X + 3), (int)(_position.Y + 5), boundingBoxWidth, boundingBoxHeight);
            boxColor = Color.Red;
        }
        public void ChangeActionState(GoombaActionState newState)
        {
            eState = newState;
            ((GoombaSprite)eSprite).changeActionState(newState);
        }
        
        public override void Halt()
        {
            _position -= _velocity;
            eState.Halt();
        }

        public void ChangeToDeadState()
        {
            eState.ChangeToDead();
        }
        public override void JumpedOn()
        {
            eState.JumpedOn();
        }
    }

}
