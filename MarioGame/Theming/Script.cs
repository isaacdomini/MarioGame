using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using MarioGame.States;
using MarioGame.States.BlockStates.PowerUpStates;

namespace MarioGame.Theming
{
    public class Script
    {
        private readonly Scene _scene;

        private CollisionHandler collisionHandler;


        public List<Entity> _entities { get; private set; }

        //possibile TODO: cache the getters if performance suffers
        public List<Block> _blocks { get { return _entities.FindAll(e => e is Block).ConvertAll(e => (Block) e); } }
        public List<Item> _items { get { return _entities.FindAll(e => e is Item).ConvertAll(e => (Item) e); } }
        public List<Enemy> _enemies { get { return _entities.FindAll(e => e is Enemy).ConvertAll(e => (Enemy) e); } }

        //TODO: clean up below line's code smell
        public Mario mario { get { return (Mario)_entities.Find(e => e is Mario); } }
        public Script(Scene scene)
        {
            _scene = scene;
        }

        private Game1 Game1
        {
            get { return _scene.Stage.Game1; }
        }

        private GraphicsDeviceManager GraphicsDeviceManager
        {
            get { return _scene.Stage.GraphicsDevice; }
        }

        private Viewport Viewport
        {
            get { return GraphicsDeviceManager.GraphicsDevice.Viewport; }
        }

        public void Initialize()
        {
		    _entities = new List<Entity>();
            collisionHandler = new CollisionHandler();
        }

        public void Update(GameTime gameTime)
        {
            bool colliding = false;
            foreach (var block in _blocks)
            {
                block.Update();
                if (collisionHandler.checkForCollision(mario, block))
                {
                    mario.Halt();
                    colliding = true;
                    //if (collisionHandler.checkSideCollision(mario, block))
                }
            }
            if (Mario.invincibleTimer == 0)
            {
                if(mario.PowerUpState is FireStarState)
                {
                    mario.ChangeToFireState();
                }
                else if (mario.PowerUpState is StandardStarState)
                {
                    mario.ChangeToStandardState();
                }
                else if (mario.PowerUpState is SuperStarState)
                {
                    mario.ChangeToSuperState();
                }

                foreach (var enemy in _enemies)
                {

                    if (collisionHandler.checkForCollision(mario, enemy) && !enemy.IsDead())
                    {
                        colliding = true;
                        enemy.boxColor = Color.Black;
                        if(mario.PowerUpState is SuperStarState || mario.PowerUpState is FireStarState || mario.PowerUpState is StandardStarState)
                        {
                            enemy.JumpedOn();
                        }
                        else if (collisionHandler.checkSideCollision(mario, enemy) == CollisionTypes.Top)
                        {
                            enemy.JumpedOn();
                            mario.Halt();
                        }
                        else
                        {
                            if (mario.isCollidable == true)
                            {
                                if (enemy.Hurts())
                                {
                                    mario.EnemyHit();
                                }
                                else
                                {
                                    enemy.JumpedOn();
                                    mario.Halt();
                                    if (collisionHandler.checkSideCollision(mario, enemy) == CollisionTypes.Right)
                                        ((KoopaTroopa)enemy).ChangeShellVelocityDirection();
                                }
                            }
                        }
                    }
                    else
                    {
                        enemy.boxColor = Color.Red;
                        mario.isCollidable = true;
                        foreach (var block in _blocks)
                        {
                            if (collisionHandler.checkForCollision(enemy, block))
                            {
                                ((KoopaTroopa)enemy).ChangeShellVelocityDirection();
                            }
                        }
                    }
                    enemy.Update(Viewport);

                }
            }
            else
            {
                Mario.invincibleTimer--;

                    foreach (var enemy in _enemies)
                    {

                        if (collisionHandler.checkForCollision(mario, enemy) && !enemy.IsDead())
                        {
                            colliding = true;
                            enemy.boxColor = Color.Black;
                            if (mario.PowerUpState is SuperStarState || mario.PowerUpState is FireStarState || mario.PowerUpState is StandardStarState)
                            {
                                enemy.JumpedOn();
                            }
                        }
                        else
                        {
                            enemy.boxColor = Color.Red;
                            mario.isCollidable = true;
                            foreach (var block in _blocks)
                            {
                                if (collisionHandler.checkForCollision(enemy, block))
                                {
                                    ((KoopaTroopa)enemy).ChangeShellVelocityDirection();
                                }
                            }
                        }
                        enemy.Update(Viewport);

                    }
                }

            foreach (var item in _items)
            {
                if (item.isCollidable)
                {
                    if (collisionHandler.checkForCollision(mario, item))
                    {
                        colliding = true;
                        item.boxColor = Color.Black;
                        if (item is Coin)
                        {
                            //Add code to add coin to total coins
                        }
                        else if (item is Star)
                        {
                            mario.ChangeToStarState();
                        }
                        else if (item is FireFlower)
                        {
                            mario.ChangeToFireState();
                        }
                        else if (item is Mushroom1Up)
                        {
                            //Add code to add extra life
                        }
                        else if (item is MushroomSuper)
                        {
                            mario.ChangeToSuperState();
                        }
                        item.makeInvisible();
                        item.isCollidable = false;
                    }
                    else
                    {
                        item.boxColor = Color.Green;
                    }
                }
            }
            if (colliding)
            {
                mario.boxColor = Color.Black;
            }
            else
            {
                mario.boxColor = Color.Yellow;
            }
            mario.Update(Viewport);

        }

        public void AddEntity(Entity entity)
        {
            _entities.Add(entity);
        }

        internal void MakeMarioJump()
        {
            mario.Jump();
        }
        internal void MakeMarioCrouch()
        {
            mario.Crouch();
        }
        internal void MakeMarioDashOrThrowFireball()
        {
            mario.DashOrThrowFireball();
        }
        internal void MakeMarioMoveLeft()
        {
            mario.MoveLeft();
        }
        internal void MakeMarioMoveRight()
        {
            mario.MoveRight();
        }
        internal void MakeMarioFire()
        {
            mario.ChangeToFireState();
        }
        internal void MakeMarioStandard()
        {
            mario.ChangeToStandardState();
        }
        internal void MakeMarioSuper()
        {
            mario.ChangeToSuperState();
        }
        internal void MakeMarioDead()
        {
            mario.ChangeToDeadState();
        }
        internal void BrickBumpOrBreak()
        {
            foreach (var block in _blocks)
            {
                if (block.CurrentActionState is BrickBlockState)
                {
                    if (mario.PowerUpState is SuperState)
                    {
                        block.Break();
                    }
                    else if (mario.PowerUpState is StandardState)
                    {
                        block.Bump();
                        block.ChangeToUsed();
                    }
                }
            }
        }
        internal void ShowHiddenBlock()
        {
            foreach(Block block in _blocks)
            {
                block.Reveal();
            }
        }
        internal void ChangeQuestionToUsed()
        {
            foreach (Block block in _blocks)
            {
                if (block.CurrentActionState is QuestionBlockState)
                block.ChangeToUsed();
            }
        }
    }
}
