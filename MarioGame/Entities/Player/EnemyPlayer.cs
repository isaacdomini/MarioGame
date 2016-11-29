
using System;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.States;
using Microsoft.Xna.Framework;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class EnemyPlayer : Enemy
    {
        private EnemyPlayerSprite EnemyPlayerSprite => (EnemyPlayerSprite)EnemySprite;
        public EnemyPlayerActionState EnemyPlayerActionState => (EnemyPlayerActionState)AState;
        private static readonly Vector2 JumpingVelocity = new Vector2(0, VelocityConstant * -2);

        public EnemyPlayer(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            BoxPercentSizeOfEntity = 1f;
            var stateMachine = new EnemyPlayerStateMachine(this);
            ChangeActionState(stateMachine.WalkingState);
            AState.Begin(AState);
        }
        //TODO: couldn't we just inherit ChangeActionState from some parent
        public void ChangeActionState(EnemyPlayerActionState newState)
        {
            AState = newState;
            EnemyPlayerSprite.ChangeActionState(newState);
        }
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            AState.UpdateEntity(elapsedMilliseconds);
        }
        public void MoveRight()
        {
            if (!(EnemyPlayerActionState is EnemyPlayerDeadState))
            {
                EnemyPlayerActionState.MoveRight();
            }
        }
        public void Jump()
        {
            //TODO: factor this logic somehow into marioPowerUpState so that mario doesn't have to keep track of what power up state he is inn
            SetVelocityToJumping();

        }
        public void SetVelocityToJumping()
        {
            SetYVelocity(JumpingVelocity);
        }
        public void MoveLeft()
        {
            if (!(EnemyPlayerActionState is EnemyPlayerDeadState))
            {
                EnemyPlayerActionState.MoveLeft();
            }
        }
    }
}
