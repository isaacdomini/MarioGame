
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
        GoombaActionState eState { get { return (GoombaActionState)aState; } }
        GoombaStateMachine stateMachine;
        GoombaSprite _goombaSprite { get { return (GoombaSprite)_sprite; } }
        public Goomba(Vector2 position, ContentManager content) : base(position, content)
        {
            stateMachine = new GoombaStateMachine(this);
            aState = stateMachine.WalkingGoomba;
        }
        //TODO: couldn't we just inherit ChangeActionState from some parent
        public void ChangeActionState(GoombaActionState newState)
        {
            aState = newState;
            _goombaSprite.changeActionState(newState);
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
        }
    }
}
