using System;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.States;
using Microsoft.Xna.Framework;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using MarioGame.Core;

namespace MarioGame.Entities
{
    public class Pirahna : Enemy
    {
        private PirahnaSprite PirahnaSprite => (PirahnaSprite)EnemySprite;

        public Pirahna(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            var stateMachine = new PirahnaStateMachine(this);
            ChangeActionState(stateMachine.AliveState);
            AState.Begin(AState);
        }
        public void ChangeActionState(PirahnaActionState newState)
        {
            AState = newState;
            PirahnaSprite.ChangeActionState(newState);
        }
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            AState.UpdateEntity(elapsedMilliseconds);
        }

        public override void OnCollideMario(Mario mario, Sides side)
        {
            if (mario.CanKillPirhana)
            {
                EnemyActionState.ChangeToDead();
            }
        }

    }
}