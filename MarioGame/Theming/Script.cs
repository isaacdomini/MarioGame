using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;
using MarioGame.States;

namespace MarioGame.Theming
{
    public class Script
    {
        private readonly Scene _scene;
        public List<Entity> Entities { get; private set; }

        //possibile TODO: cache the getters if performance suffers
        public List<Block> Blocks { get { return Entities.FindAll(e => e is Block).ConvertAll(e => (Block) e); } }
        public List<Item> Items { get { return Entities.FindAll(e => e is Item).ConvertAll(e => (Item) e); } }
        public List<Enemy> Enemies { get { return Entities.FindAll(e => e is Enemy).ConvertAll(e => (Enemy) e); } }
        public float LevelWidth;
 
        //TODO: clean up below line's code smell
        public Mario Mario { get { return (Mario)Entities.Find(e => e is Mario); } }
        public Script(Scene scene)
        {
            _scene = scene;
        }

        private Game1 Game1 => _scene.Stage.Game1;
        private GraphicsDeviceManager GraphicsDeviceManager => _scene.Stage.GraphicsDevice;
        private Viewport Viewport => GraphicsDeviceManager.GraphicsDevice.Viewport;

        public void Initialize()
        {
		    Entities = new List<Entity>();
        }

        public void Update(GameTime gameTime)
        {
            UpdateCamera(gameTime);
            var entityPairs = new List<int>();
            Entities = Entities.FindAll(e => !e.Deleted);
            Entities.FindAll(e => e.Moving).ForEach(e =>
           {
               Entities.FindAll(e2 => e.BoundingBox.Intersects(e2.BoundingBox)).ForEach(e2 =>
               {
                   if(!entityPairs.Contains(e.GetHashCode() ^ e2.GetHashCode()))
                   {
                       var eSide = CollisionHandler.GetIntersectingSide(e.BoundingBox, e2.BoundingBox);
                       e.OnCollide(e2, eSide);
                       e2.OnCollide(e, Util.flip(eSide));
                       entityPairs.Add(e.GetHashCode() ^ e2.GetHashCode());
                   }
                });

           });
            Entities.ForEach(e => e.Update(Viewport, gameTime));
            Console.WriteLine(Mario.Position.X);

        }
        public void updateItemVisibility(Layer layer)
        {
            Entities = Entities.FindAll(e => !e.Deleted);
            foreach (Entity e in Entities)
            {
                if (layer.WorldToScreen(e.Position).X > (layer._camera._viewport.Bounds.Right))
                {
                    e._isVisible = false;
                    e.IsCollidable = false;
                }
                else
                {
                    e._isVisible = true;
                    e.IsCollidable = true;
                }
            }
        }
        private void UpdateCamera(GameTime gameTime)
        {
            
            if(Mario.Position.X >= (GlobalConstants.GridWidth * LevelWidth) - (Viewport.Width / 3.0f))
            {
                _scene.Camera.LookAt(new Vector2((GlobalConstants.GridWidth * LevelWidth) - (Viewport.Width / 3.0f),0));
                _scene.updateItemVisibility();
            }
            else if (Mario.Position.X >= Viewport.Width / 3.0f)
            {
                _scene.Camera.LookAt(Mario.Position);
                _scene.updateItemVisibility();
            }
        }

        public void AddEntity(Entity entity)
        {
            Entities.Add(entity);
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
            foreach (var block in Blocks)
            {
                if (!(block.CurrentActionState is BrickBlockState)) continue;
                if (Mario.MarioPowerUpState is SuperState)
                {
                    block.Break();
                }
                else if (Mario.MarioPowerUpState is StandardState)
                {
                    block.Bump();
                    block.ChangeToUsed();
                }
            }
        }
        internal void ShowHiddenBlock()
        {
            Blocks.ForEach(b => b.Show());
        }
        internal void ChangeQuestionToUsed()
        {
            Blocks.FindAll(b => b.CurrentActionState is QuestionBlockState).ForEach(b => b.ChangeToUsed());
        }
        internal void DrawBoundingBoxes()
        {
            _scene.DrawBoundingBoxes();
        }

    }
}
