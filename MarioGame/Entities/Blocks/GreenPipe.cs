using System;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class GreenPipe : Block
    {
        internal bool Inverted { get; private set; }
        public Action<Mario, Vector2> SceneTransport { get; private set; }
        internal Vector2 TransportPosition { get; private set; }
        public GreenPipe(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            Inverted = false;
        }

        internal void SetInversion(bool inverted)
        {
            Inverted = inverted;
        }
        internal void SetSceneTransport(Action<Mario, Vector2> sceneTransport)
        {
            SceneTransport = sceneTransport;
        }
        internal void SetTransportPosition(Vector2 newPosition)
        {
            TransportPosition = newPosition;
        }
    }
}
