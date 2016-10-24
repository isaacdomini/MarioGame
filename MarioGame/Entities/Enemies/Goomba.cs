
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
        GoombaStateMachine _stateMachine;
        GoombaSprite _goombaSprite { get { return (GoombaSprite)_sprite; } }
        public Goomba(Vector2 position, ContentManager content) : base(position, content)
        {
            _stateMachine = new GoombaStateMachine(this);
            ChangeActionState(_stateMachine.WalkingGoomba);
            aState.Begin(aState);
            isCollidable = true;
        }
        //TODO: couldn't we just inherit ChangeActionState from some parent
        public void ChangeActionState(GoombaActionState newState)
        {
            aState = newState;
            _goombaSprite.changeActionState(newState);
        }
    }
}
