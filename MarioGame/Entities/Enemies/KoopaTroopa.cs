﻿using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States;
using MarioGame.Theming;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    public class KoopaTroopa : Enemy
    {
        protected KoopaTroopaSprite KoopaTroopaSprite => (KoopaTroopaSprite) EnemySprite;
        protected KoopaActionState KoopaActionState => (KoopaActionState) EnemyActionState;
        //public KoopaTroopaSprite eSprite;

        private const float ShellMovingXSpeed = 2f;
        private Vector2 ShellMovingVelocity => new Vector2(FacingLeft ? -1*ShellMovingXSpeed : ShellMovingXSpeed, 0);


        public KoopaTroopa(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content,addToScriptEntities)
        {
            var stateMachine = new KoopaStateMachine(this);
            ChangeActionState(stateMachine.WalkingState);
            AState.Begin(AState);
        }
        //TODO: couldn't we delete this method and just let the parent method be used?
        public void ChangeActionState(KoopaActionState newState)
        {
            AState = newState;
            KoopaTroopaSprite.ChangeActionState(newState);
        }

        internal void SetShellVelocityToMoving()
        {
            this.SetVelocity(ShellMovingVelocity);
        }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            if (Position.X < 0)
            {
                PositionX = 0;
                TurnRight();
            }
            if (_secondsOfInvincibilityRemaining > 0)
            {
                _secondsOfInvincibilityRemaining--;
            }
        }
    }
}