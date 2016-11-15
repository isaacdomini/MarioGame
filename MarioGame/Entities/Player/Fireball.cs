using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.Player
{
    internal class Fireball :Entity
    {
        public Fireball(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, float xVelocity = 0, float yVelocity = 0) : base(position, content, addToScriptEntities, xVelocity, yVelocity)
        {
        }

        public override void OnCollide(IEntity otherObject, Sides ownSide, Sides otherSide)
        {
            if (otherObject is Mario || otherObject is Item) return;
            Delete();
        }
    }
}
