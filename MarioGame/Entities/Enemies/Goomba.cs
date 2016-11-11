
using System;
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
        private GoombaSprite GoombaSprite => (GoombaSprite)EnemySprite;

        public Goomba(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            var stateMachine = new GoombaStateMachine(this);
            ChangeActionState(stateMachine.WalkingState);
            AState.Begin(AState);
        }
        //TODO: couldn't we just inherit ChangeActionState from some parent
        public void ChangeActionState(GoombaActionState newState)
        {
            AState = newState;
            GoombaSprite.ChangeActionState(newState);
        }
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            AState.UpdateEntity(elapsedMilliseconds);
        }
    }
}
