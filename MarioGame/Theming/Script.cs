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
        }

        public void Update(GameTime gameTime)
        {
            List<int> entityPairs = new List<int>();
            _entities = _entities.FindAll(e => !e.Deleted);
            _entities.FindAll(e => e.Moving).ForEach(e =>
           {
               _entities.FindAll(e2 => e.boundingBox.Intersects(e2.boundingBox)).ForEach(e2 =>
               {
                   if(!entityPairs.Contains(e.GetHashCode() ^ e2.GetHashCode()))
                   {
                       Sides eSide = CollisionHandler.getIntersectingSide(e.boundingBox, e2.boundingBox);
                       e.onCollide(e2, eSide);
                       e2.onCollide(e, Util.flip(eSide));
                       entityPairs.Add(e.GetHashCode() ^ e2.GetHashCode());
                   }
                   else
                   {
                       Console.WriteLine("Type" + e.GetType());
                   }
                });

           });
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
                    if (mario.marioPowerUpState is SuperState)
                    {
                        block.Break();
                    }
                    else if (mario.marioPowerUpState is StandardState)
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
