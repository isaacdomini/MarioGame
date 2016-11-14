using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Checkpoint : Item
    {
        public Checkpoint(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities)
            : base(position, content, addToScriptEntities)
        {
        }
    }

}
