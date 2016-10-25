
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
        private GoombaSprite GoombaSprite => (GoombaSprite)Sprite;

        public Goomba(Vector2 position, ContentManager content) : base(position, content)
        {
            var stateMachine = new GoombaStateMachine(this);
            ChangeActionState(stateMachine.WalkingGoomba);
            AState.Begin(AState);
            IsCollidable = true;
        }
        //TODO: couldn't we just inherit ChangeActionState from some parent
        public void ChangeActionState(GoombaActionState newState)
        {
            AState = newState;
            GoombaSprite.ChangeActionState(newState);
        }
    }
}
