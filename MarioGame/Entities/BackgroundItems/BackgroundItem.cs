using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Theming;
using MarioGame.Core;

namespace MarioGame.Entities
{
    public class BackgroundItem : Entity
    {
        public int Layer { get; set; }// TODO: Should this actually be public? Could we have a public wrapper for a protected setter?
        public BackgroundItem(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            floating = true;
            BoxPercentSizeOfEntity = 0f;
        }
        internal override void Init(JEntity e, Game1 Game1)
        {
            Layer = e.backgroundlayer; 
        }
    }
}
