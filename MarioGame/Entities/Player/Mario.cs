using Microsoft.Xna.Framework;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using MarioGame.Core;
using MarioGame.Theming;
using System;

namespace MarioGame.Entities
{
    public class Mario : PowerUpEntity
    {
        private float _secondsOfInvincibilityRemaining = 0.0f;
        public bool Invincible => _secondsOfInvincibilityRemaining > 0 || PState is FireStarState || PState is StandardStarState || PState is SuperStarState;
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState MarioPowerUpState => (MarioPowerUpState)PState;
        public MarioActionState MarioActionState => (MarioActionState)AState;
        private MarioActionStateMachine marioActionStateMachine;
        // TODO: maybe we don't have to give the casted variable a new name, but rather just use the new keyword and the subclass type
        protected MarioSprite MarioSprite => (MarioSprite)Sprite;

        // Velocity variables
        private static readonly Vector2 JumpingVelocity = new Vector2(0, VelocityConstant * -2);
        private static readonly Vector2 DashVelocity = new Vector2(VelocityConstant * 2, 0);

        private const int SuperBoundingBoxWidth = 20;
        private const int SuperBoundingBoxHeight = 36;

        private const int StandardBoundingBoxWidth = 20;
        private const int StandardBoundingBoxHeight = 20;

        private enum SpaceBarAction
        {
            Walk,
            Run
        }

        private SpaceBarAction _spaceBarAction;

        public Mario(Vector2 position, ContentManager content) : base(position, content)
        {
            marioActionStateMachine = new MarioActionStateMachine(this);
            var marioPowerUpStateMachine = new MarioPowerUpStateMachine(this);           
            AState = marioActionStateMachine.IdleMarioState; //TODO: make marioActionState a casted getter of aState?
            PState = marioPowerUpStateMachine.StandardState;
            IsCollidable = true;
            Direction = Directions.Right;
            _spaceBarAction = SpaceBarAction.Run;
        }
        protected override void SetUpBoundingBoxProperties()
        {
            const int sideMargin = 0;
            var topBottomMargin = 0;
            if (MarioPowerUpState is FireStarState || MarioPowerUpState is SuperState || MarioPowerUpState is FireState || MarioPowerUpState is SuperStarState)
            {
                BoundingBoxSize = new Point(SuperBoundingBoxWidth, SuperBoundingBoxHeight);
            }
            else
            {
                BoundingBoxSize = new Point(StandardBoundingBoxWidth, StandardBoundingBoxHeight);
                topBottomMargin = 16;
            }
            BoundingBoxOffset = new Point(sideMargin, topBottomMargin);
        }
        private void OnInvincibilityEnded()
        {
            if(MarioPowerUpState is FireStarState)
            {
               ChangeToFireState();
            }
            else if (MarioPowerUpState is StandardStarState)
            {
                ChangeToStandardState();
            }
            else if (MarioPowerUpState is SuperStarState)
            {
                ChangeToSuperState();
            }
        }
        private void UpdateInvincibilityStatus()
        {
            if (!(_secondsOfInvincibilityRemaining > 0)) return;
            _secondsOfInvincibilityRemaining -= (GlobalConstants.MillisecondsPerFrame / 1000);
            if (_secondsOfInvincibilityRemaining <= 0)
            {
                OnInvincibilityEnded();
            }
        }
        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
            MarioActionState.UpdateEntity(gameTime);
            UpdateInvincibilityStatus();

            SetXVelocity(Vector2.Zero);
        }
        public void ChangeActionState(MarioActionState state)
        {
            base.ChangeActionState(state);
            MarioSprite.ChangeActionState(state);
        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            base.ChangePowerUpState(state);
            LoadBoundingBox();
            MarioSprite.ChangePowerUp(state);//TODO: can we push _marioSprite.changePowerUp inside of base.ChangePowerUpState, or will doing so lose the polymorphism (e.g. will it call AnimatedSprite.changePowerUp rather than _marioSprite.changePowerUp
        }
        public void Jump()
        {
            //TODO: factor this logic somehow into marioPowerUpState so that mario doesn't have to keep track of what power up state he is inn
            if (!(MarioPowerUpState is DeadState))
            {
                MarioActionState.Jump();
            }
        }
        public void Crouch()
        {
            //TODO: make actionState take a StateFactory so the way we check pState and action State below can be consistent
            if (MarioPowerUpState is StandardState && (MarioActionState).actionState == MarioActionStateEnum.Idle)
            {
                MarioActionState.Fall();
            }
            else if (!(MarioPowerUpState is DeadState))
            {
                MarioActionState.Crouch();
            }
        }
        public void MoveLeft()
        {
            if (!(MarioPowerUpState is DeadState))
            {
                MarioActionState.MoveLeft();
            }
        }
        public void MoveRight()
        {
            if (!(MarioPowerUpState is DeadState))
            {
                MarioActionState.MoveRight();
            }
        }
        public void ChangeToFireState()
        {
            MarioPowerUpState.ChangeToFire();
        }
        public void ChangeToStandardState()
        {
            MarioPowerUpState.ChangeToStandard();
        }
        public void ChangeToSuperState()
        {
            MarioPowerUpState.ChangeToSuper();
        }
        public void ChangeToStarState()
        {
            MarioPowerUpState.ChangeToStar();
        }
        public void ChangeToDeadState()
        {
            MarioPowerUpState.ChangeToDead();
        }
        //Todo: I don't like that we have a method called DashOrThrowFireball. I think we should have a Dash() method and a throwFireball() method, and which one gets called gets handled in the State classes
        public void DashOrThrowFireball()
        {
            //TODO: Ricky do this?
            if (PState is FireState || PState is FireStarState)
            {
                // TODO: Mario entity adds fireball to scene

            }
            else if (PState is SuperState)
            {
                switch (_spaceBarAction)
                {
                    case SpaceBarAction.Walk:
                        _velocity = Velocity / 2;
                        _spaceBarAction = SpaceBarAction.Run;
                        break;
                    case SpaceBarAction.Run:
                        _velocity = Velocity * 2;
                        _spaceBarAction = SpaceBarAction.Walk;
                        break;
                }
            }
        }
        
        public void SetVelocityToJumping()
        {
            SetYVelocity(JumpingVelocity);
        }
        public override void Halt()
        {
            _position -= Velocity;
            HaltX();
            HaltY();
            MarioActionState.Halt();
        }
        private void OnCollideEnemy(Enemy enemy, Sides side)
        {
            if (Invincible) return;
            if (!enemy.Dead && side != Sides.Bottom)
            {
                MarioPowerUpState.OnHitByEnemy();
            }
            else
            {
                Halt();
                _position -= new Vector2(0, 15);
            }
        }
        protected override void OnBlockSideCollision()
        {
            _position.X -= 2 * Velocity.X;
            HaltX();
            MarioActionState.Halt();
        }
        public override void OnBlockBottomCollision()
        {
            base.OnBlockBottomCollision();
            HaltY();

            //ChangeActionState(marioActionStateMachine.IdleMarioState);
        }
        public override void OnBlockTopCollision()
        {
            base.OnBlockTopCollision();
            //MarioActionState.Fall();
        }
        private void OnCollideItem(Item item, Sides side)
        {
            if (item is Coin)
            {
                //Add code to add coin to total coins
            }
            else if (item is Star)
            {
                ChangeToStarState();
            }
            else if (item is FireFlower)
            {
                ChangeToFireState();
            }
            else if (item is Mushroom1Up)
            {
                //Add code to add extra life
            }
            else if (item is MushroomSuper)
            {
                ChangeToSuperState();
            }
        }
        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            base.OnCollide(otherObject, side, otherSide);
            if (otherObject is Enemy)
            {
                OnCollideEnemy((Enemy)otherObject, side);
            }
            else if (otherObject is Item)
            {
                OnCollideItem((Item)otherObject, side);
            }
       }
        public void SetInvincible(float seconds)
        {
            _secondsOfInvincibilityRemaining = seconds;
        }
    }

}
