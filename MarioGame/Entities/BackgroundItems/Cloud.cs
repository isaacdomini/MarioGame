using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    internal class Cloud : Entity
    {
        public Cloud(Vector2 position, ContentManager content) : base(position, content)
        {
            floating = true;
        }

    }
}
