using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using MarioGame.States;
using MarioGame.Commands;

namespace MarioGame.Theming
{
    public class Script
    {
        private readonly Scene _scene;
        public AudioManager AudioManager { get; set; }
        public List<Entity> Entities { get; private set; }
        //possibile TODO: cache the getters if performance suffer
        public List<Block> Blocks => Entities.FindAll(e => e is Block).ConvertAll(e => (Block) e);
        public List<Item> Items => Entities.FindAll(e => e is Item).ConvertAll(e => (Item) e);
        public List<Enemy> Enemies => Entities.FindAll(e => e is Enemy).ConvertAll(e => (Enemy) e);
        public Mario Mario => (Mario)Entities.Find(e => e is Mario);
        private GraphicsDeviceManager GraphicsDeviceManager => _scene.Stage.GraphicsDevice;
        private Viewport Viewport => GraphicsDeviceManager.GraphicsDevice.Viewport;
        public float LevelWidth { get; set; }
        public string BackgroundMusic { get; set; }
        //TODO: clean up below line's code smell

        public Script(Scene scene)
        {
            _scene = scene;
        }


        public void Initialize()
        {
		    Entities = new List<Entity>();
            Entity.RegisterScript(this);
        }

        public void Update(GameTime gameTime)
        {
            UpdateCamera();
            var entityPairs = new List<int>();
            Entities = Entities.FindAll(e => !e.Deleted);
            Entities.FindAll(e => e.Moving).ForEach(e =>
            {
               Entities.FindAll(e2 => e.BoundingBox.Intersects(e2.BoundingBox)).ForEach(e2 =>
               {
                   if (entityPairs.Contains(e.GetHashCode() ^ e2.GetHashCode())) return;
                   var eSide = CollisionHandler.GetIntersectingSide(e.BoundingBox, e2.BoundingBox);
                   var e2Side = CollisionHandler.GetIntersectingSide(e2.BoundingBox, e.BoundingBox);
                   // This would only be true when the bottom of a hidden block collides with the bottom of Mario
                   if (!(e is Item))
                   {
                       e.OnCollide(e2, eSide, e2Side);
                       e2.OnCollide(e, e2Side, eSide);
                   }
                   else
                   {
                       e2.OnCollide(e, e2Side, eSide);
                       e.OnCollide(e2, eSide, e2Side);
                   }
                       entityPairs.Add(e.GetHashCode() ^ e2.GetHashCode());
               });
            });
            Entities.ForEach(e => e.Update(Viewport, gameTime.ElapsedGameTime.Milliseconds));

        }
        public void UpdateItemVisibility(Layer layer)
        {
            Entities = Entities.FindAll(e => !e.Deleted);
            foreach (Entity e in Entities)
            {
                if (layer.WorldToScreen(e.Position).X > (layer.Camera.Viewport.Bounds.Right))
                {
                    if (e is IHidable)
                    {
                        ((IHidable)e).OffScreen();
                    }
                }
                else
                {
                    if(e is IHidable)
                    {
                        ((IHidable)e).OnScreen();
                    }
                }
            }
        }
        private void UpdateCamera()
        {
            
            if(Mario.Position.X >= (GlobalConstants.GridWidth * LevelWidth) - (Viewport.Width / 3.0f))
            {
                _scene.Camera.LookAt(new Vector2((GlobalConstants.GridWidth * LevelWidth) - (Viewport.Width / 3.0f),0));
                _scene.UpdateItemVisibility();
            }
            else if (Mario.Position.X >= Viewport.Width / 3.0f)
            {
                _scene.Camera.LookAt(Mario.Position);
                _scene.UpdateItemVisibility();
            }
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
            if (entity is BackgroundItem)
            {
                _scene.AddToLayer(((BackgroundItem) entity).Layer, entity.Sprite);
            }
            else
            {
                _scene.AddActionSprite(entity.Sprite);
            }

        }
        public void RemoveEntity(Entity entity)
        {
            Entities.Remove(entity);
        }

        internal void MakeMarioJump()
        {
            Mario.Jump();
        }
        internal void MakeMarioCrouch()
        {
            Mario.Crouch();
        }
        internal void MakeMarioDashOrThrowFireball()
        {
            Mario.DashOrThrowFireball();
        }
        internal void MakeMarioMoveLeft()
        {
            Mario.MoveLeft();
        }
        internal void MakeMarioMoveRight()
        {
            Mario.MoveRight();
        }
        internal void MakeMarioFire()
        {
            Mario.ChangeToFireState();
        }
        internal void MakeMarioStandard()
        {
            Mario.ChangeToStandardState();
        }
        internal void MakeMarioSuper()
        {
            Mario.ChangeToSuperState();
        }
        internal void MakeMarioDead()
        {
            Mario.ChangeToDeadState();
        }
        internal void BrickBumpOrBreak()
        {
            Blocks.FindAll(b => b is BrickBlock).ForEach(block =>
            {
                var brickBlock = (BrickBlock) block;
                if (Mario.CanBreakBricks)
                {
                    brickBlock.Break();
                }
                else
                {
                    brickBlock.Bump();
                }
            });
        }
        internal void ChangeQuestionToUsed()
        {
            Blocks.FindAll(b => b is QuestionBlock).ForEach(b => b.ChangeToUsed());
        }
        internal void ShowHiddenBlock()
        {
            Blocks.ForEach(b => b.Show());
        }
        internal void DrawBoundingBoxes()
        {
            _scene.DrawBoundingBoxes();
        }
        internal void Reset()
        {
            _scene.Game1.ResetCommand();
        }
    }
}
