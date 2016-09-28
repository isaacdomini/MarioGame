using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.Entities.BlockEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioGame.Theming
{
    public class Script
    {
        private readonly Scene _scene;

        public MarioEntity mario { get; private set; }
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
    }
}
