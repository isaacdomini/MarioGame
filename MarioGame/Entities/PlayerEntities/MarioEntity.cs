
using System;
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using MarioGame.States.PlayerStates.PowerUpStates;
using Microsoft.Xna.Framework;
using MarioGame.Sprites;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
        private PowerUpState pState;
        // Could be useful for casting in certain circumstances
        public MarioSprite mSprite;

        // Velocity variables
        public readonly static int velocityConstant = 1;
        public readonly static Vector2 walkingRightVelocity = new Vector2(velocityConstant*1, 0);
        public readonly static Vector2 walkingLeftVelocity = new Vector2(velocityConstant *- 1, 0);
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        public readonly static Vector2 jumpingUpVelocity = new Vector2(0, velocityConstant*1);
        public readonly static Vector2 jumpingRightVelocity = new Vector2(velocityConstant*1, velocityConstant*1);
        public readonly static Vector2 jumpingLeftVelocity = new Vector2(velocityConstant*- 1, velocityConstant*1);
        public readonly static Vector2 FallingVelocity = new Vector2(0, velocityConstant*- 1);



        public MarioEntity(Vector2 position, ISprite sprite) : base(position, sprite)
        {
            aState = new IdleMarioState(this);
            aState.setDirection(ActionState.Directions.Right);
            pState = new StandardState(this);
            // Now only cast once
            mSprite = (MarioSprite)_sprite;
        }

        public Vector2 position
        {
            get { return mSprite._position; }
            set { mSprite._position = value; }
        }

        public void Load()
        {
        }

        public override void Update()
        {
            
        }
        public void ChangeActionState(ActionState state)
        {
            aState = state;
            aState.setDirection(state.direction);
            
        }
        public void ChangePowerUpState(PowerUpState state)
        {
            // TODO Is this all we need? Or do we need below methods
            pState = state;
        }
        public void Jump()
        {
            aState.Jump();
        }
        public void Crouch()
        {
            aState.Crouch();
        }
        public void WalkLeft()
        {
            aState.MoveLeft();
        }
        public void WalkRight()
        {
            aState.MoveRight();
        }
        public void ChangeToFireState()
        {
            pState.ChangeToFire();
        }
        public void ChangeToStandardState()
        {
            pState.ChangeToStandard();
        }
        public void ChangeToSuperState()
        {
            pState.ChangeToSuper();
        }
        public void ChangeToDeadState()
        {
            pState.ChangeToDead();
        }
        public void DashOrThrowFireball()
        {
            //TODO: Ricky do this?
        }
    }
}
