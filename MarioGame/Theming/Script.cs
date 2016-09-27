using MarioGame.Core;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Theming
{
    public class Script
    {
        private readonly Scene _scene;

        private MarioEntity mario;

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