using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

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
                if (collisionHandler.checkForCollision(mario, block))
                {
                    mario.Halt();
                    colliding = true;
                }
            }
            foreach (var enemy in _enemies)
            {
                if (collisionHandler.checkForCollision(mario, enemy))
                {
                    colliding = true;
                    mario.Halt();
                    enemy.boxColor = Color.Black;
                    if (collisionHandler.checkSideCollision(mario, enemy) == CollisionTypes.Top)
                    {
                        enemy.JumpedOn();
                    }
                    else
                    {
                        // Need to switch isCollidable based on powerUpState 
                        //so that mario can technically walk through enemies after taking damage
                        //Mario shouldn't die when koopa is an idle shell. Only when shell is moving or Koopa is alive
                        if (mario.isCollidable == true)
                        {
                            mario.EnemyHit();
                        }
                    }
                }
                else
                {
                    enemy.boxColor = Color.Red;
                    mario.isCollidable = true;
                }
                enemy.Update(Viewport);

            }
            foreach (var item in _items)
            {
                if (collisionHandler.checkForCollision(mario, item))
                {
                    colliding = true;
                    item.boxColor = Color.Black;
                    if (item.GetType() == typeof(Coin))
                    {
                        //Add code to add coin to total coins
                    }
                    else if (item.GetType() == typeof(Star))
                    {
                        //Add code to make Mario invinsible
                    }
                    else if (item.GetType() == typeof(FireFlower))
                    {
                        mario.ChangeToFireState();
                    }
                    else if (item.GetType() == typeof(Mushroom1Up))
                    {
                        //Add code to add extra life
                    }
                    else if (item.GetType() == typeof(MushroomSuper))
                    {
                        mario.ChangeToSuperState();
                    }
                    item.makeInvisible();
                }
                else
                {
                    item.boxColor = Color.Green;
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
        internal void BrickBump()
        {
            foreach (var block in _blocks)
            {
                if (block is BrickBlock)
                {
                    block.Bump();
                }
            }
        }
        internal void ChangeQuestionToUsed()
        {
            throw new NotImplementedException();
        }
        internal void ShowHiddenBlock()
        {

        }
    }
}
