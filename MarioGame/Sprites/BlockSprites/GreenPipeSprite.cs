using MarioGame.Entities;
using MarioGame.States;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MarioGame.Sprites
{
    public class GreenPipeSprite : HidableSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {
        public GreenPipeSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            AssetName = "GreenPipe";
        }
    }
}