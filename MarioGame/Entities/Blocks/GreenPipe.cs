using System;
using MarioGame.Core;
using MarioGame.Theming;
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

        internal override void Init(JEntity e, Game1 game)
        {
            base.Init(e, game);
            SetInversion(e.inverted);
            if (e.transportPosition != null)
            {
                float x = (float)(e.transportPosition.columns.ToArray()).GetValue(0);
                float y = e.transportPosition.row;
                Vector2 transportPosition = new Vector2(x, y);
                SetTransportPosition(transportPosition);
            }

            // Checks to see if green pipe is meant to transport mario somewhere
            if (e.sceneTransport != null)
            {
                if (e.sceneTransport == "HiddenLevel")
                {
                    SetSceneTransport(game.EnterHiddenScene);
                }
                else if (e.sceneTransport == "Level1")
                {
                    SetSceneTransport(game.ExitHiddenScene);
                }

            }
                   
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
