﻿using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Entities.Blocks;
using MarioGame.Entities.PlayerEntities;
using MarioGame.States.PlayerStates;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using MarioGame.Entities.Enemies;
using MarioGame.Entities.Items;

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
	    public List<Block> _blocks { get; private set; }


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
		    _blocks = new List<Block>();
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
                    if(enemy.GetType() == typeof(KoopaTroopa))
                    {
                        CollisionTypes returned = collisionHandler.checkSideCollision(mario, enemy);
                        Console.WriteLine(returned);
                        if (collisionHandler.checkSideCollision(mario, enemy) == CollisionTypes.Left)
                        {
                            enemy.boxColor = Color.Black;
                            mario.ChangeToDeadState();
                        }
                    }
                    else if(enemy.GetType() == typeof(Goomba))
                    {
                        enemy.boxColor = Color.Black;
                        mario.ChangeToDeadState();
                    }
                    //_mario.Halt();
                    colliding = true;
                    mario.Halt();
                }
                else
                {
                    enemy.boxColor = Color.Red;
                }

            }
            foreach (var item in _items)
            {
                if (collisionHandler.checkForCollision(mario, item))
                {
                    colliding = true;
                    if (item.GetType() == typeof(Coin))
                    {
                        item.boxColor = Color.Black;
                    }
                    else if (item.GetType() == typeof(Star))
                    {
                        item.boxColor = Color.Black;
                    }
                    else if (item.GetType() == typeof(FireFlower))
                    {
                        mario.ChangeToFireState();
                        item.boxColor = Color.Black;
                    }
                    else if (item.GetType() == typeof(Mushroom1Up))
                    {
                        item.boxColor = Color.Black;
                    }
                    else if (item.GetType() == typeof(MushroomSuper))
                    {
                        mario.ChangeToSuperState();
                        item.boxColor = Color.Black;
                    }
                }
                else
                {
                    item.boxColor = Color.Green;
                }
            }
            if (colliding)
            {
                mario.boxColor = Color.Black;
            } else
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

	    public void AddBlock(Block block)
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
