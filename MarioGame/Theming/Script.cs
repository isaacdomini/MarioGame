using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Entities.BlockEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.States.PlayerStates;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using MarioGame.Entities.EnemyEntities;
using MarioGame.Entities.ItemEntities;
using MarioGame.States;

namespace MarioGame.Theming
{
    public class Script
    {
        private readonly Scene _scene;

        private CollisionHandler collisionHandler;

        public MarioEntity mario { get; private set; }

        public List<Entity> _entities { get; private set; }
	    public List<Entity> _enemies { get; private set; }
	    public List<Entity> _items { get; private set; }
	    public List<BlockEntity> _blocks { get; private set; }


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
		    _enemies = new List<Entity>();
		    _items = new List<Entity>();
		    _blocks = new List<BlockEntity>();
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
                        enemy.Halt();
                    }
                    else
                    {
                        // Need to switch isCollidable based on powerUpState 
                        //so that mario can technically walk through enemyies after taking damage
                        if (mario.isCollidable == true)
                        {
                            mario.ChangeToDeadState();
                        }
                    }
                }
                else
                {
                    enemy.boxColor = Color.Red;
                    mario.isCollidable = true;
                }

            }
            foreach (var item in _items)
            {
                if (collisionHandler.checkForCollision(mario, item))
                {
                    colliding = true;
                    item.boxColor = Color.Black;
                    if (item.GetType() == typeof(CoinEntity))
                    {
                        //Add code to add coin to total coins
                    }
                    else if (item.GetType() == typeof(StarEntity))
                    {
                        //Add code to make Mario invinsible
                    }
                    else if (item.GetType() == typeof(FireFlowerEntity))
                    {
                        mario.ChangeToFireState();
                    }
                    else if (item.GetType() == typeof(Mushroom1UpEntity))
                    {
                        //Add code to add extra life
                    }
                    else if (item.GetType() == typeof(MushroomSuperEntity))
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


        public void AddMario(MarioEntity marioEntity)
        {
            mario = marioEntity;
        }

	    public void AddEnemy(Entity enemy)
	    {
		    _enemies.Add(enemy);
	    }

	    public void AddItem(Entity item)
	    {
		    _items.Add(item);
	    }

	    public void AddBlock(BlockEntity block)
	    {
		    _blocks.Add(block);
	    }

        public void MakeMarioJump()
        {
            mario.Jump();
        }
        public void MakeMarioCrouch()
        {
            mario.Crouch();
        }
        public void MakeMarioDashOrThrowFireball()
        {
            mario.DashOrThrowFireball();
        }
        public void MakeMarioMoveLeft()
        {
            mario.WalkLeft();
        }
        public void MakeMarioMoveRight()
        {
            mario.WalkRight();
        }
        public void MakeMarioFire()
        {
            mario.ChangeToFireState();
        }
        public void MakeMarioStandard()
        {
            mario.ChangeToStandardState();
        }
        public void MakeMarioSuper()
        {
            mario.ChangeToSuperState();
        }
        public void MakeMarioDead()
        {
            mario.ChangeToDeadState();
        }
        public void BreakBrick()
        {
            //Need to implement still
        }
    }
}
