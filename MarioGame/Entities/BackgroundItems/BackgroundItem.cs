﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    internal class BackgroundItem : Entity
    {
        public int Layer;// TODO: Should this actually be public? Could we have a public wrapper for a protected setter?
        public BackgroundItem(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            floating = true;
        }

    }
}