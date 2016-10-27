using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Sprites
{
    public abstract class HidableSprite : AnimatedSprite
    {
        public bool isVisible
        {
            get { return ((IHidable)Entity).IsVisible; }
        }
        public HidableSprite(ContentManager content, Entity entity) : base(content, entity)
        {
        }

    }
}
