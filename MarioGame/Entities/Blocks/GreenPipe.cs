using System;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class GreenPipe : Block
    {
        internal bool Inverted { get; private set; }
        public Action<Mario> SceneTransport { get; private set; }
        public GreenPipe(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            Inverted = false;
        }

        internal void SetInversion(bool inverted)
        {
            Inverted = inverted;
        }
        internal void SetSceneTransport(Action<Mario> sceneTransport)
        {
            SceneTransport = sceneTransport;
        }
    }
}
