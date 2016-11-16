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
        private Vector2 _startPos;
        private int _moving; //0 = Not Moving, 1 = Moving Up, 2 = Moving Down

        public Pirahna(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            BoxPercentSizeOfEntity = .8f;
            var stateMachine = new PirahnaStateMachine(this);
            ChangeActionState(stateMachine.AliveState);
            AState.Begin(AState);
            _startPos = Position;
            _moving = 1;
            floating = true;
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
            if (_moving == 1) //Moving Up
            {
                PositionY -= .2f;
                if (Position.Y <= _startPos.Y)
                    _moving = 2;
            }
            else if (_moving == 2) //Moving Down
            {
                PositionY += .2f;
                if (Position.Y >= _startPos.Y + 20)
                    _moving = 0;
            }
            else //Not Moving
            {
                if (Script.Mario != null)
                {
                    if (!(Script.Mario.Position.X + Script.Mario.Width > Position.X - (Script.Mario.Width / 2f) &&
                        Script.Mario.Position.X < Position.X + Width + (Script.Mario.Width / 2f)))
                    {
                        _moving = 1;
                    }
                }
            }
        }

        public override void OnCollideMario(Mario mario, Sides side)
        {
            if (mario.CanKillPirahna)
            {
                EnemyActionState.ChangeToDead();
            }
        }

    }
}