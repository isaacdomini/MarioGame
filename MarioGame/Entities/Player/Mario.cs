using Microsoft.Xna.Framework;
using MarioGame.Sprites;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using MarioGame.Core;
using MarioGame.Theming;
using System;
using System.Collections.Generic;
using MarioGame.Theming.Scenes;

namespace MarioGame.Entities
{
    public class Mario : PowerUpEntity
    {
        //private float _secondsOfInvincibilityRemaining = 0.0f;
        // Could be useful for casting in certain circumstances
        public MarioPowerUpState MarioPowerUpState => (MarioPowerUpState)PState;
        public MarioActionState MarioActionState => (MarioActionState)AState;
        // TODO: maybe we don't have to give the casted variable a new name, but rather just use the new keyword and the subclass type
        protected MarioSprite MarioSprite => (MarioSprite)Sprite;
        public static Scoreboard Scoreboard = new Scoreboard();

        // Velocity variables
        private static readonly Vector2 JumpingVelocity = new Vector2(0, VelocityConstant * -2);

        private const int SuperBoundingBoxWidth = 18;
        private const int SuperBoundingBoxHeight = 36;

        private const int StandardBoundingBoxWidth = 14;
        private const int StandardBoundingBoxHeight = 20;
        private bool IsLarge => MarioPowerUpState is SuperState || MarioPowerUpState is SuperStarState || MarioPowerUpState is FireState || MarioPowerUpState is FireStarState;
        public bool CanBreakBricks => IsLarge;
        public bool Invincible => _secondsOfInvincibilityRemaining > 0 || PState is FireStarState || PState is StandardStarState || PState is SuperStarState;
        private enum SpaceBarAction
        {
            Walk,
            Run
        }

        private SpaceBarAction _spaceBarAction;
        internal float LevelWidth;
        private Vector2 _currentCheckpointPosition;
        private bool _checkpointReached = false; //set true for testing
        public Action EnterHiddenRoom { get; private set; }

        public Action ExitHiddenRoom { get; private set; }
        public static Action EnterGameOver { get; private set; }

        private readonly MarioActionStateMachine _marioActionStateMachine;
        private readonly MarioPowerUpStateMachine _marioPowerUpStateMachine;

        public Mario(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            _marioActionStateMachine = new MarioActionStateMachine(this);
            _marioPowerUpStateMachine = new MarioPowerUpStateMachine(this);
            AState = _marioActionStateMachine.IdleMarioState; //TODO: make marioActionState a casted getter of aState?
            PState = _marioPowerUpStateMachine.StandardState;
            Direction = Directions.Right;
            _spaceBarAction = SpaceBarAction.Run;
        }

        
        protected override void SetUpBoundingBoxProperties()//TODO: All bounding box logic should really be in sprite classes, not entity classes
        {
            int JumpingBoundingBoxWidth = StandardBoundingBoxWidth + 3;
            int boxWidth = StandardBoundingBoxWidth, boxHeight = StandardBoundingBoxHeight;
            int sideMargin = 0;
            var topBottomMargin = 0;
            if (IsLarge)//TODO: This logic perhaps should be handled by the state
            {
                boxWidth = SuperBoundingBoxWidth;
                boxHeight = SuperBoundingBoxHeight;
                sideMargin = 2;
            }
            else
            {
                BoundingBoxSize = new Point(StandardBoundingBoxWidth, StandardBoundingBoxHeight);
                if (MarioActionState is JumpingMarioState || MarioActionState is FallingMarioState)
                {
                    boxWidth = JumpingBoundingBoxWidth;
                }
                else
                {
                    sideMargin = 3;
                }
                topBottomMargin = 16;
            }
            BoundingBoxSize = new Point(boxWidth, boxHeight);
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
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            MarioPowerUpState.UpdateEntity(elapsedMilliseconds);
            MarioActionState.UpdateEntity(elapsedMilliseconds);
            UpdateInvincibilityStatus();
            MarioActionState.CheckForLevelEdges();
            SetXVelocity(Vector2.Zero);
            Scoreboard.UpdateTimer(elapsedMilliseconds);
            CheckFallOff(viewport);
        }
        private void CheckFallOff(Viewport viewport)
        {
            if(_position.Y>viewport.Height)
            {
                ChangeToDeadState();
            }
        }

        
        public void ChangeActionState(MarioActionState state)
        {
            base.ChangeActionState(state);
            LoadBoundingBox();
            MarioSprite.ChangeActionState(state);
        }
        public void ChangePowerUpState(MarioPowerUpState state)
        {
            if(!(this.PState is SuperStarState || this.PState is FireStarState || this.PState is StandardStarState))
            {
                if (state is SuperState || state is FireState)
                {
                    Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.powerup.GetHashCode()]);
                }
                else if (state is StandardState)
                {
                    Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.powerdown.GetHashCode()]);
                }
            }
            else if(!(state is SuperStarState || state is FireStarState || state is StandardStarState))
            {
                Script.AudioManager.StopStarMode();
            }
            if(state is SuperStarState || state is FireStarState || state is StandardStarState)
            {
                Script.AudioManager.StartStarMode();
            }
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
            if (MarioPowerUpState is FireState || MarioPowerUpState is FireStarState)
            {
                // TODO: Mario entity adds fireball to scene

            }
            else if (MarioPowerUpState is SuperState)
            {
                switch (_spaceBarAction)
                {
                    case SpaceBarAction.Walk:
                        _velocity = _velocity / 2;
                        _spaceBarAction = SpaceBarAction.Run;
                        break;
                    case SpaceBarAction.Run:
                        _velocity = _velocity * 2;
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
            _position -= _velocity;
            HaltX();
            HaltY();
            MarioActionState.Halt();
        }

        protected override void OnCollideHiddenBlock(Block block, Sides side, Sides blockSide)
        {
            if (side == Sides.Top && blockSide == Sides.Bottom && Velocity.Y < 0)
            {
                Halt();
            }
        }

        private void OnCollideEnemy(Enemy enemy, Sides side)
        {
            if (Invincible) return;
            if(enemy is Pirahna && (MarioPowerUpState is StandardState || MarioPowerUpState is SuperState))
            {
                MarioPowerUpState.OnHitByEnemy();
            }
            else if (enemy.IsVisible && side != Sides.Bottom )
            {
                if (enemy._secondsOfInvincibilityRemaining <= 0)
                {
                    MarioPowerUpState.OnHitByEnemy();
                }
            }
            else
            {
                Halt();
                _position -= new Vector2(0, 15);
            }
        }
        protected override void OnBlockSideCollision(Sides side)
        {
            if (side == Sides.Right)
                _position.X -= 2;
            else
                _position.X += 2;
            HaltX();
            MarioActionState.Halt();
        }

        protected override void OnBlockBottomCollision(Block block)
        {
            base.OnBlockBottomCollision();
            if (block is GreenPipe)
            {
                MarioActionState.HitTopOfGreenPipe(((GreenPipe)block).SceneTransport, ((GreenPipe)block).Inverted);
            }
        }
        protected override void OnBlockTopCollision(Block block)
        {
            base.OnBlockTopCollision();
            if (block is GreenPipe)
            {
                MarioActionState.HitBottomOfGreenPipe(((GreenPipe)block).SceneTransport, ((GreenPipe)block).Inverted);
            }
        }
        private void OnCollideItem(Item item)
        {
            if (!item.IsVisible) return;
            if (item is Coin)
            {
                Scoreboard.AddCoin();
            }
            else if (item is Star)
            {
                ChangeToStarState();
                Scoreboard.AddPoint(1000);
            }
            else if (item is FireFlower)
            {
                ChangeToFireState();
                Scoreboard.AddPoint(1000);
            }
            else if (item is Mushroom1Up)
            {
                Scoreboard.AddPoint(1000);
            }
            else if (item is MushroomSuper)
            {
                ChangeToSuperState();
                Scoreboard.AddPoint(1000);
            }
            else if (item is Checkpoint)
            {
                _currentCheckpointPosition = item.Position;
                //_currentCheckpointPosition = (int) item.Position.X;
                _checkpointReached = true;
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
                OnCollideItem((Item)otherObject);
            }
       }
        public void SetInvincible(float seconds)
        {
            _secondsOfInvincibilityRemaining = seconds;
        }
        internal void SetHiddenRoomEntry(Action enterHiddenScene)
        {
            EnterHiddenRoom = enterHiddenScene;
        }

        internal void SetHiddenRoomDeparture(Action exitHiddenScene)
        {
            ExitHiddenRoom = exitHiddenScene;
        }
        public override void GoToHiddenRoom()
        {
            EnterHiddenRoom();
        }
        protected override void LeaveHiddenRooom()
        {
            ExitHiddenRoom();
        }
        public static void GoToGameOver()
        {
            EnterGameOver();
        }
        internal void SetGameOver(Action enterGameOver)
        {
            EnterGameOver = enterGameOver;
        }

        public void RespawnOrGameOver()
        {
            if (Scoreboard.HasLives)
            {
                if (_checkpointReached)
                {
                    MoveToLocation(_currentCheckpointPosition);
                    ChangeActionState(_marioActionStateMachine.IdleMarioState);
                    ChangePowerUpState(_marioPowerUpStateMachine.StandardState);
                    //Script.Reset();
                }
                else
                {
                    Script.Reset();
                }
            }
            else
            {
               //TODO: End GAME 
            }
        }

        private void MoveToLocation(Vector2 xPosition)
        {
            xPosition.Y -= 15f;
            _position = xPosition; //*GlobalConstants.GridWidth;
        }
    }

}
